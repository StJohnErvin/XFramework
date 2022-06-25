﻿

using HealthEssentials.Domain.Generics.Contracts.Responses.Unit;

namespace HealthEssentials.Domain.Generics.Contracts.Responses.Medicine;

public class MedicineIntakeResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public string? Name { get; set; }
    public string? ScientificName { get; set; }
    public string? Description { get; set; }
    public long? Repetition { get; set; }
    public string Guid { get; set; } = null!;

    public MedicineIntakeEntityResponse Entity { get; set; } = null!;
    public UnitResponse? Unit { get; set; }
}