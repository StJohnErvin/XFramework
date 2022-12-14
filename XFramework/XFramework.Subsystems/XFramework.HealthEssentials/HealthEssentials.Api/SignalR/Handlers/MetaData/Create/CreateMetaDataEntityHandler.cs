using HealthEssentials.Core.DataAccess.Commands.Entity.MetaData;
using HealthEssentials.Domain.Generics.Contracts.Requests.MetaData.Create;

namespace HealthEssentials.Api.SignalR.Handlers.MetaData.Create;

public class CreateMetaDataEntityHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestCmd<CreateMetaDataEntityRequest, CreateMetaDataEntityCmd>(connection, mediator);
    }
}