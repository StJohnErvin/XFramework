using Messaging.Core.DataAccess.Commands.Entity.Message;
using Messaging.Domin.Generic.Contracts.Requests.Create;
using Messaging.Domin.Generic.Contracts.Requests.Update;

namespace Messaging.Api.SignalR.Handlers.Message;

public class ConfirmMessageSentHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleVoidRequestCmd<ConfirmMessageSentRequest, ConfirmMessageSentCmd>(connection, mediator);
    }
}