using HealthEssentials.Domain.Generics.Contracts.Requests.Hospital.Update;

namespace HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

public class UpdateHospitalLaboratoryCmd : UpdateHospitalLaboratoryRequest, IRequest<CmdResponse<UpdateHospitalLaboratoryCmd>>
{
    
}