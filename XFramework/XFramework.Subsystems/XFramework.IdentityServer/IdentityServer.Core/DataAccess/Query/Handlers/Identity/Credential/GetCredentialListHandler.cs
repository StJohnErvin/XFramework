using IdentityServer.Core.DataAccess.Query.Entity.Identity.Credentials;
using IdentityServer.Domain.Generic.Contracts.Responses;
using XFramework.Integration.Interfaces;
using XFramework.Integration.Interfaces.Wrappers;

namespace IdentityServer.Core.DataAccess.Query.Handlers.Identity.Credential;

public class GetCredentialListHandler : QueryBaseHandler, IRequestHandler<GetCredentialListQuery, QueryResponse<List<CredentialResponse>>>
{

    public GetCredentialListHandler(IDataLayer dataLayer, ICachingService cachingService, IHelperService helperService, JwtOptionsBO jwtOptionsBo, IJwtService jwtService, ILoggerWrapper recordsWrapper)
    {
        _dataLayer = dataLayer;
        _cachingService = cachingService;
    }
        
    public async Task<QueryResponse<List<CredentialResponse>>> Handle(GetCredentialListQuery request, CancellationToken cancellationToken)
    {
        
        var appEntity = await _dataLayer.Applications.FirstOrDefaultAsync(i => i.Guid == $"{request.ApplicationGuid}", cancellationToken);
        if (appEntity == null)
        {
            return new ()
            {
                Message = $"Application with guid '{request.ApplicationGuid}' not found",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        
        var result = await _dataLayer.IdentityCredentials
            .Where(i => i.ApplicationId == appEntity.Id)
            .Include(i => i.IdentityInfo)
            .Include(i => i.IdentityRoles)
            .ThenInclude(i => i.RoleEntity)
            .Include(i => i.IdentityContacts)
            .ThenInclude(i => i.Entity)
            .OrderBy(i => i.CreatedAt)
            .Take(request.PageSize)
            .AsNoTracking()
            .AsSplitQuery()
            .ToListAsync(cancellationToken: cancellationToken);

        if (!result.Any())
        {
            return new ()
            {
                Message = $"No credentials exist",
                HttpStatusCode = HttpStatusCode.NoContent
            };
        }

        return new ()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Response = result.Adapt<List<CredentialResponse>>()
        };
    }

}