﻿

namespace HealthEssentials.Domain.Generics.Contracts.Responses.Vendor;

public class VendorEntityResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; } = null!;
    public string Guid { get; set; } = null!;
    public int? SortOrder { get; set; }

    public VendorEntityGroupResponse Group { get; set; } = null!;
}