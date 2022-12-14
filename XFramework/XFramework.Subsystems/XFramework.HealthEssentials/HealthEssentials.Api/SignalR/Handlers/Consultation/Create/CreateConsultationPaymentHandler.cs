using HealthEssentials.Core.DataAccess.Commands.Entity.Consultation;
using HealthEssentials.Core.DataAccess.Query.Entity.Doctor;
using HealthEssentials.Domain.Generics.Contracts.Requests.Consultation;
using HealthEssentials.Domain.Generics.Contracts.Requests.Consultation.Create;
using HealthEssentials.Domain.Generics.Contracts.Requests.Doctor;

namespace HealthEssentials.Api.SignalR.Handlers.Consultation.Create;

public class CreateConsultationPaymentHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestCmd<CreateConsultationPaymentRequest, CreateConsultationPaymentCmd>(connection, mediator);
    }
}