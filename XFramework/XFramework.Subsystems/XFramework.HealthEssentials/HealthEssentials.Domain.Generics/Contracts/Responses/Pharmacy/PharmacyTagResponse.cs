using HealthEssentials.Domain.Generics.Contracts.Responses.Tag;

namespace HealthEssentials.Domain.Generics.Contracts.Responses.Pharmacy;

public class PharmacyTagResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public string? Value { get; set; }
    public Guid? Guid { get; set; }

    public PharmacyResponse? Pharmacy { get; set; }
    public TagResponse? Tag { get; set; }
}