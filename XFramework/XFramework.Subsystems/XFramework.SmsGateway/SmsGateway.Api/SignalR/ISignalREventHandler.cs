namespace SmsGateway.Api.SignalR;

public interface ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator);
}