namespace IdentityServer.Api.SignalR.Handlers;

public class GetCredentialHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestQuery<GetCredentialRequest, GetCredentialQuery, CredentialResponse>(connection, mediator);
    }
}