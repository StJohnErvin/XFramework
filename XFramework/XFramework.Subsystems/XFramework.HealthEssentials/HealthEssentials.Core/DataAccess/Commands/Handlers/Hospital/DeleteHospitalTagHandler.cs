using HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Hospital;

public class DeleteHospitalTagHandler : CommandBaseHandler, IRequestHandler<DeleteHospitalTagCmd, CmdResponse<DeleteHospitalTagCmd>>
{
    public DeleteHospitalTagHandler()
    {
        
    }
    public async Task<CmdResponse<DeleteHospitalTagCmd>> Handle(DeleteHospitalTagCmd request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}