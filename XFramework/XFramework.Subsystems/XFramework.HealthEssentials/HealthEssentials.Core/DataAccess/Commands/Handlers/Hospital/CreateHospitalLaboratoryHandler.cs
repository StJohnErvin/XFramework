using HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Hospital;

public class CreateHospitalLaboratoryHandler : CommandBaseHandler, IRequestHandler<CreateHospitalLaboratoryCmd, CmdResponse<CreateHospitalLaboratoryCmd>>
{
    public CreateHospitalLaboratoryHandler()
    {
        
    }
    public async Task<CmdResponse<CreateHospitalLaboratoryCmd>> Handle(CreateHospitalLaboratoryCmd request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}