﻿namespace IdentityServer.Core.DataAccess.Commands.Handlers.Identity.Credential;

public class CreateCredentialHandler : CommandBaseHandler, IRequestHandler<CreateCredentialCmd, CmdResponse<CreateCredentialCmd>>
{

    public CreateCredentialHandler(IDataLayer dataLayer)
    {
        _dataLayer = dataLayer;
    }
    public async Task<CmdResponse<CreateCredentialCmd>> Handle(CreateCredentialCmd request, CancellationToken cancellationToken)
    {
        var application = await GetApplication(request.RequestServer.ApplicationId);
        var identityInfo = await _dataLayer.IdentityInformations.FirstOrDefaultAsync(i => i.Guid == $"{request.IdentityGuid}", cancellationToken: cancellationToken);
        var entity = request.Adapt<IdentityCredential>();
            
        if (identityInfo == null)
        {
            return new CmdResponse<CreateCredentialCmd>
            {
                Message = $"Identity with Guid {request.Guid} does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        if (string.IsNullOrEmpty(request.UserName))
        {
            goto SkipDuplicateCheck;
        }
        
        var anyCredential = _dataLayer.IdentityCredentials
            .AsNoTracking()
            .Any(i => i.UserName == request.UserName);
            
        if (anyCredential)
        {
            return new()
            {
                Message = $"Username '{request.UserName}' already exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        
        SkipDuplicateCheck:
        var hashPasswordByte = Encoding.ASCII.GetBytes(BCrypt.Net.BCrypt.HashPassword(inputKey: request.Password, workFactor:11));

        entity.Guid = request.Guid != null ? request.Guid.ToString() : Guid.NewGuid().ToString();
        entity.PasswordByte = hashPasswordByte;
        entity.IdentityInfoId = identityInfo.Id;
        entity.ApplicationId = application.Id;

        await _dataLayer.IdentityCredentials.AddAsync(entity, cancellationToken);
            
        var roleEntity = await _dataLayer.IdentityRoleEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Guid == $"{request.RoleEntity}", cancellationToken: cancellationToken);

        if (roleEntity == null)
        {
            return new ()
            {
                Message = $"Role with Guid '{request.RoleEntity}' does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        var role = new IdentityRole()
        {
            UserCred = entity,
            RoleEntityId = roleEntity.Id,
            IsEnabled = true
        };

        await _dataLayer.IdentityRoles.AddAsync(role, cancellationToken);
        await _dataLayer.SaveChangesAsync(cancellationToken);

        return new ()
        {
            HttpStatusCode = HttpStatusCode.Accepted
        };
    }
}