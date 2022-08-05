﻿namespace HealthEssentials.Domain.Generics.Contracts.Requests.Tag.Create;

public class CreateTagEntityRequest : RequestBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? GroupGuid { get; set; }
    public int? SortOrder { get; set; }
}