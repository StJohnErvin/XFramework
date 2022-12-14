

namespace HealthEssentials.Domain.Generics.Contracts.Responses.Unit;

public class UnitResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? Description { get; set; }
    public Guid? Guid { get; set; }

    public UnitEntityResponse? Entity { get; set; }
}