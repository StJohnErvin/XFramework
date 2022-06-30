﻿using XFramework.Domain.Generic.Contracts.Requests;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Laboratory;

public class UpdateLaboratoryServiceEntityRequest : RequestBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? GroupGuid { get; set; }    
}