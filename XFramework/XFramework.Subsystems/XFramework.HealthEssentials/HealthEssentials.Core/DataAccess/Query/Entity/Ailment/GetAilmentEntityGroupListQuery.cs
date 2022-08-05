﻿using HealthEssentials.Domain.DataTransferObjects.XnelSystemsHealthEssentials;
using HealthEssentials.Domain.Generics.Contracts.Requests.Ailment;
using HealthEssentials.Domain.Generics.Contracts.Requests.Ailment.Get;
using HealthEssentials.Domain.Generics.Contracts.Responses.Ailment;

namespace HealthEssentials.Core.DataAccess.Query.Entity.Ailment;

public class GetAilmentEntityGroupListQuery : GetAilmentEntityGroupListRequest, IRequest<QueryResponse<List<AilmentEntityGroupResponse>>>
{
    
}