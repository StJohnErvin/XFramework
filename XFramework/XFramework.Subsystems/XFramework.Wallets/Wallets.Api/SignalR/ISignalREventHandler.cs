namespace Wallets.Api.SignalR;

public interface ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator);
}