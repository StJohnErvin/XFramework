using HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Hospital;

public class DeleteHospitalEntityGroupHandler : CommandBaseHandler, IRequestHandler<DeleteHospitalEntityGroupCmd, CmdResponse<DeleteHospitalEntityGroupCmd>>
{
    public DeleteHospitalEntityGroupHandler()
    {
        
    }
    public async Task<CmdResponse<DeleteHospitalEntityGroupCmd>> Handle(DeleteHospitalEntityGroupCmd request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}