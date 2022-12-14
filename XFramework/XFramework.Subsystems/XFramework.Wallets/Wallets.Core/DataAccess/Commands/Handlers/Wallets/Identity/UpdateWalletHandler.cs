using Wallets.Core.DataAccess.Commands.Entity.Wallets.Identity;

namespace Wallets.Core.DataAccess.Commands.Handlers.Wallets.Identity;

public class UpdateWalletHandler : CommandBaseHandler, IRequestHandler<UpdateWalletCmd, CmdResponse<UpdateWalletCmd>>
{
    public UpdateWalletHandler(IDataLayer dataLayer, IMediator mediator)
    {
        _mediator = mediator;
        _dataLayer = dataLayer;
    }
        
    public async Task<CmdResponse<UpdateWalletCmd>> Handle(UpdateWalletCmd request, CancellationToken cancellationToken)
    {
        var credentialEntity = await _dataLayer.IdentityCredentials.FirstOrDefaultAsync(i => i.Guid == $"{request.CredentialGuid}", cancellationToken);
        if (credentialEntity == null)
        {
            return new ()
            {
                Message = $"Credential with Guid {request.CredentialGuid} does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        
        var walletEntity = await _dataLayer.WalletEntities.FirstOrDefaultAsync(i => i.Guid == $"{request.WalletEntityGuid}", cancellationToken);
        if (walletEntity == null)
        {
            return new ()
            {
                Message = $"Wallet with Guid {request.CredentialGuid} does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        
        var entity = await _dataLayer.Wallets
            .Where(i => i.IdentityCredentialId == credentialEntity.Id)
            .Where(i => i.WalletEntityId == walletEntity.Id)
            .FirstOrDefaultAsync(cancellationToken);
        if (entity == null)
        {
            await _mediator.Send(new CreateWalletCmd
            {
                RequestServer = request.RequestServer,
                ClientReference = request.ClientReference,
                CredentialGuid = request.CredentialGuid,
                WalletEntityGuid = request.WalletEntityGuid,
                Balance = 0
            }, CancellationToken.None);
            
            entity = await _dataLayer.Wallets
                .Where(i => i.IdentityCredentialId == credentialEntity.Id)
                .Where(i => i.WalletEntityId == walletEntity.Id)
                .FirstOrDefaultAsync(cancellationToken);
            /*return new ()
            {
                Message = $"Credential Guid: {request.CredentialGuid} with Wallet Guid: {request.WalletEntityGuid} does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };*/
        }
            
        entity = request.Adapt(entity);
        _dataLayer.Update(entity);
        await _dataLayer.SaveChangesAsync(cancellationToken);

        return new()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Message = $"Wallet Guid:{request.WalletEntityGuid} has been updated successfully."
        };
    }
        
}