using HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Hospital;

public class DeleteHospitalServiceEntityGroupHandler : CommandBaseHandler, IRequestHandler<DeleteHospitalServiceEntityGroupCmd, CmdResponse<DeleteHospitalServiceEntityGroupCmd>>
{
    public DeleteHospitalServiceEntityGroupHandler()
    {
        
    }
    public async Task<CmdResponse<DeleteHospitalServiceEntityGroupCmd>> Handle(DeleteHospitalServiceEntityGroupCmd request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}