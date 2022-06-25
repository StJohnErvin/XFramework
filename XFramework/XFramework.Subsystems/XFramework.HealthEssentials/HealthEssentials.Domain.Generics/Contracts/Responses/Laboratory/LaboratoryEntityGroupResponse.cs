﻿namespace HealthEssentials.Domain.Generics.Contracts.Responses.Laboratory;

public class LaboratoryEntityGroupResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; } = null!;
    public Guid? Guid { get; set; }
}