using HealthEssentials.Domain.Generics.Contracts.Requests.Doctor.Get;
using HealthEssentials.Domain.Generics.Contracts.Responses.Doctor;

namespace HealthEssentials.Core.DataAccess.Query.Entity.Doctor;

public class GetDoctorEntityListQuery : GetDoctorEntityListRequest, IRequest<QueryResponse<List<DoctorEntityResponse>>>
{
    
}