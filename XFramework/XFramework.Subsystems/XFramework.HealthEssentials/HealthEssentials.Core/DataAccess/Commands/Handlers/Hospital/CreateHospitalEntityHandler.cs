using HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Hospital;

public class CreateHospitalEntityHandler : CommandBaseHandler, IRequestHandler<CreateHospitalEntityCmd, CmdResponse<CreateHospitalEntityCmd>>
{
    public CreateHospitalEntityHandler()
    {
        
    }
    public async Task<CmdResponse<CreateHospitalEntityCmd>> Handle(CreateHospitalEntityCmd request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}