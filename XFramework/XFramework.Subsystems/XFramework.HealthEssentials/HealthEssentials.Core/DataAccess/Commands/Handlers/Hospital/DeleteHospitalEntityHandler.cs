using HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Hospital;

public class DeleteHospitalEntityHandler : CommandBaseHandler, IRequestHandler<DeleteHospitalEntityCmd, CmdResponse<DeleteHospitalEntityCmd>>
{
    public DeleteHospitalEntityHandler()
    {
        
    }
    public async Task<CmdResponse<DeleteHospitalEntityCmd>> Handle(DeleteHospitalEntityCmd request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}