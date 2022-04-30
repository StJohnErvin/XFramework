﻿using IdentityServer.Core.DataAccess.Commands.Entity.Identity.Verification;

namespace IdentityServer.Core.DataAccess.Commands.Handlers.Identity.Verification;

public class UpdateVerificationHandler : CommandBaseHandler, IRequestHandler<UpdateVerificationCmd, CmdResponse>
{
    public UpdateVerificationHandler(IDataLayer dataLayer)
    {
        _dataLayer = dataLayer;
    }
    
    
    public async Task<CmdResponse> Handle(UpdateVerificationCmd request, CancellationToken cancellationToken)
    {
        var verification = await _dataLayer.IdentityVerifications.FirstOrDefaultAsync(i => i.Guid == $"{request.Guid}", CancellationToken.None);
        if (verification == null)
        {
            return new ()
            {
                Message = $"Verification with Guid {request.Guid} does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        verification.Status = (short?) request.Status;
        _dataLayer.IdentityVerifications.Update(verification);
        await _dataLayer.SaveChangesAsync(CancellationToken.None);

        return new()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            IsSuccess = true
        };
    }
}