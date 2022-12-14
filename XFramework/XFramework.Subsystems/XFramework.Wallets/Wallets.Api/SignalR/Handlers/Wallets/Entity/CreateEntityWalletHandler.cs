using Wallets.Core.DataAccess.Commands.Entity.Wallets;
using Wallets.Domain.Generic.Contracts.Requests.Create;

namespace Wallets.Api.SignalR.Handlers.Wallets.Entity;

public class CreateEntityWalletHandler  : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestCmd<CreateWalletEntityRequest, CreateWalletEntityCmd>(connection, mediator);
    }
}