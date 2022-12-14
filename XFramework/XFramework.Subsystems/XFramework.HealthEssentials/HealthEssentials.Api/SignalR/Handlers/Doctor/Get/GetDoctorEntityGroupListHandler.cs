using HealthEssentials.Core.DataAccess.Query.Entity.Doctor;
using HealthEssentials.Domain.Generics.Contracts.Requests.Doctor.Get;
using HealthEssentials.Domain.Generics.Contracts.Responses.Doctor;

namespace HealthEssentials.Api.SignalR.Handlers.Doctor.Get;

public class GetDoctorEntityGroupListHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestQuery<GetDoctorEntityGroupListRequest, GetDoctorEntityGroupListQuery, List<DoctorEntityGroupResponse>>(connection, mediator);
    }
}