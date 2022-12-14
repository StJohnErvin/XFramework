using IdentityServer.Core.DataAccess.Query.Entity.Identity.Credentials;
using IdentityServer.Domain.Generic.Contracts.Responses;
using IdentityServer.Domain.Generic.Enums;
using XFramework.Integration.Interfaces;
using XFramework.Integration.Interfaces.Wrappers;

namespace IdentityServer.Core.DataAccess.Query.Handlers.Identity.Credential;

public class AuthenticateIdentityHandler : QueryBaseHandler, IRequestHandler<AuthenticateCredentialQuery, QueryResponse<AuthorizeIdentityResponse>>
{
    public AuthenticateIdentityHandler(IDataLayer dataLayer ,ICachingService cachingService, IHelperService helperService, JwtOptionsBO jwtOptionsBo, IJwtService jwtService, ILoggerWrapper recordsWrapper)
    {
        _recordsService = recordsWrapper;
        _jwtService = jwtService;
        _jwtOptions = jwtOptionsBo;
        _helperService = helperService;
        _dataLayer = dataLayer;
        _cachingService = cachingService;
    }

    public async Task<QueryResponse<AuthorizeIdentityResponse>> Handle(AuthenticateCredentialQuery request, CancellationToken cancellationToken)
    {
        var application = await GetApplication(request.RequestServer.ApplicationId);
        if (request.Role is null)
        {
            return new QueryResponse<AuthorizeIdentityResponse>
            {
                HttpStatusCode = HttpStatusCode.BadRequest,
                Message = "Role is required"
            };
        }
        
        var credential = await ValidateAuthorization(request, cancellationToken, request.AuthorizeBy);
        if (credential == null)
        {
            return new()
            {
                Message = $"User or identity does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
            
        var cuid = new Guid(credential.Guid);
        credential = await ValidatePassword(request, request.AuthorizeBy, credential, cancellationToken);
        if (credential == null)
        {
            //_recordsService.NewAuthorizationLog(AuthenticationState.WrongPassword, cuid);
            return new()
            {
                Message = $"Wrong password",
                HttpStatusCode = HttpStatusCode.BadRequest
            };
        }

        var roleList = await GetRoleList(cancellationToken, credential, cuid);
        if (!roleList.Any(i => i.RoleEntity.Guid == $"{request.Role}"))
        {
            return new()
            {
                Message = $"You do not have permission to access this resource",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        
        var token = new JwtTokenBO();
        if (request.GenerateToken)
        {
            token = await _jwtService.GenerateToken(request.Username, cuid, roleList.Select(i => i.RoleEntityId).Adapt<List<RoleEntity>>());
        }
        //_recordsService.NewAuthorizationLog(AuthenticationState.Success, cuid);
        
        return new()
        {
            Message = $"Identity Authorized",
            HttpStatusCode = HttpStatusCode.Accepted,
            Response = new()
            {
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
                IdentityGuid = Guid.Parse(credential.IdentityInfo.Guid),
                CredentialGuid = Guid.Parse(credential.Guid),
                RoleList = roleList.Adapt<List<IdentityRoleResponse>>() 
            }
        };
    }

    private async Task<List<IdentityRole>> GetRoleList(CancellationToken cancellationToken, IdentityCredential credential, Guid cuid)
    {
        var roleList = await _dataLayer.IdentityRoles
            .AsNoTracking()
            .Include(i => i.RoleEntity)
            .Where(i => i.UserCredId == credential.Id)
            .ToListAsync(cancellationToken: cancellationToken);

        if (roleList == null)
        {
            _recordsService.NewAuthorizationLog(AuthenticationState.InvalidUser, cuid);
            return roleList;
        }

        return roleList;
    }

    private async Task<IdentityCredential> ValidateAuthorization(AuthenticateCredentialQuery request, CancellationToken cancellationToken, AuthorizeBy authorizeBy)
    {
        IdentityCredential result;
            
        var application = await GetApplication(request.RequestServer.ApplicationId);
        
        reAuth:
        switch (authorizeBy)
        {
            case AuthorizeBy.Default:
                
                var getDefaults = await _dataLayer.RegistryConfigurations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.ApplicationId == application.Id & i.Key == "DefaultAuthorizeBy", cancellationToken: cancellationToken);
                if (getDefaults is null)
                {
                    throw new ArgumentException($"Unable to login: Application with Guid '{application.Guid}' does not have 'DefaultAuthorizeBy' key in registry");
                }
                authorizeBy = (AuthorizeBy) int.Parse(getDefaults.Value);
                goto reAuth;
            case AuthorizeBy.UsernameEmailPhone:
                result = await _dataLayer.IdentityCredentials
                    .Include(i => i.IdentityInfo)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.ApplicationId == application.Id & i.UserName == request.Username,
                        cancellationToken: cancellationToken);
                result ??= _dataLayer.IdentityContacts
                    .Include(i => i.UserCredential)
                    .ThenInclude(i => i.IdentityInfo)
                    .AsNoTracking()
                    .FirstOrDefault(i => i.UserCredential.ApplicationId == application.Id & i.Value == request.Username & i.EntityId == (long?)GenericContactType.Email)?.UserCredential;
                result ??= _dataLayer.IdentityContacts
                    .Include(i => i.UserCredential)
                    .ThenInclude(i => i.IdentityInfo)
                    .AsNoTracking()
                    .FirstOrDefault(i => i.UserCredential.ApplicationId == application.Id & i.Value == request.Username.ValidatePhoneNumber(true) & i.EntityId == (long?)GenericContactType.Phone)?.UserCredential;
                break;
            case AuthorizeBy.Username:
                result = await _dataLayer.IdentityCredentials
                    .Include(i => i.IdentityInfo)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.ApplicationId == application.Id & i.UserName == request.Username,
                        cancellationToken: cancellationToken);
                break;
            case AuthorizeBy.Email:
                request.Username.ValidateEmailAddress();
                result = _dataLayer.IdentityContacts
                    .Include(i => i.UserCredential)
                    .ThenInclude(i => i.IdentityInfo)
                    .AsNoTracking()
                    .FirstOrDefault(i => i.UserCredential.ApplicationId == application.Id & i.Value == request.Username & i.EntityId == 1)?.UserCredential;
                break;
            case AuthorizeBy.Phone:
                result = _dataLayer.IdentityContacts
                    .Include(i => i.UserCredential)
                    .ThenInclude(i => i.IdentityInfo)
                    .AsNoTracking()
                    .FirstOrDefault(i => i.UserCredential.ApplicationId == application.Id & i.Value == request.Username.ValidatePhoneNumber(false) & i.EntityId == 2)?.UserCredential;
                break;
            case AuthorizeBy.Token:
                result = await _dataLayer.IdentityCredentials
                    .Include(i => i.IdentityInfo)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.UserName == request.Username,
                        cancellationToken: cancellationToken);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return result;
    }

    private async Task<IdentityCredential> ValidatePassword(AuthenticateCredentialQuery request, AuthorizeBy authorizeBy, IdentityCredential credential, CancellationToken cancellationToken)
    {
        if (authorizeBy == AuthorizeBy.Token) return credential;

        var hashPassword = Encoding.ASCII.GetString(credential.PasswordByte);
        return !BCrypt.Net.BCrypt.Verify(request.Password, hashPassword) ? null : credential;
    }

    private async Task CacheQuery(IdentityCredential result, string token)
    {
        // Add token to caching server
        var identitySession = _cachingService.IdentitySessions.FirstOrDefault(i => i.Guid == Guid.Parse(result.IdentityInfo.Guid));

        _cachingService.IdentitySessions.Remove(identitySession);
        _cachingService.IdentitySessions.Add(new IdentitySessionBO()
        {
            Token = token,
            LogonDateTime = DateTime.Now,
            SessionState = CurrentSessionState.Active,
            MaxSessionTimeSpan = TimeSpan.FromMinutes(30)
        });
    }
        
    
}