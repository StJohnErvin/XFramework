using HealthEssentials.Core.DataAccess.Commands.Entity.Consultation;
using HealthEssentials.Domain.Generics.Contracts.Requests.Consultation.Delete;

namespace HealthEssentials.Api.SignalR.Handlers.Consultation.Delete;

public class DeleteConsultationJobOrderLaboratoryHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestCmd<DeleteConsultationJobOrderLaboratoryRequest, DeleteConsultationJobOrderLaboratoryCmd>(connection, mediator);
    }
}