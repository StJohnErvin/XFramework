using HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Hospital;

public class UpdateHospitalTagHandler : CommandBaseHandler, IRequestHandler<UpdateHospitalTagCmd, CmdResponse<UpdateHospitalTagCmd>>
{
    public UpdateHospitalTagHandler()
    {
        
    }
    public async Task<CmdResponse<UpdateHospitalTagCmd>> Handle(UpdateHospitalTagCmd request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}