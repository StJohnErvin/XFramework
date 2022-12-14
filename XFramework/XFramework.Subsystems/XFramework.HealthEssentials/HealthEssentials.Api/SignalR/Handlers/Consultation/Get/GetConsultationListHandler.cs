using HealthEssentials.Core.DataAccess.Commands.Entity.Consultation;
using HealthEssentials.Core.DataAccess.Query.Entity.Consultation;
using HealthEssentials.Core.DataAccess.Query.Entity.Doctor;
using HealthEssentials.Domain.Generics.Contracts.Requests.Consultation;
using HealthEssentials.Domain.Generics.Contracts.Requests.Consultation.Get;
using HealthEssentials.Domain.Generics.Contracts.Requests.Doctor;
using HealthEssentials.Domain.Generics.Contracts.Responses.Consultation;

namespace HealthEssentials.Api.SignalR.Handlers.Consultation.Get;

public class GetConsultationListHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestQuery<GetConsultationListRequest, GetConsultationListQuery, List<ConsultationResponse>>(connection, mediator);
    }
}