﻿using XFramework.Domain.Generic.Contracts.Requests;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Laboratory;

public class GetSupportedLaboratoryServiceListRequest : QueryableRequest
{
    public Guid? LaboratoryLocationGuid { get; set; }
}