﻿namespace HealthEssentials.Domain.Generics.Contracts.Requests.Vendor.Create;

public class CreateVendorEntityRequest : RequestBase
{
    public string? Name { get; set; }
    public Guid? GroupGuid { get; set; }
    public int? SortOrder { get; set; }
}