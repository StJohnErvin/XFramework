using HealthEssentials.Core.DataAccess.Commands.Entity.Doctor;
using HealthEssentials.Domain.Generics.Contracts.Requests.Doctor.Update;

namespace HealthEssentials.Api.SignalR.Handlers.Doctor.Update;

public class UpdateDoctorTagHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestCmd<UpdateDoctorTagRequest, UpdateDoctorTagCmd>(connection, mediator);
    }
}