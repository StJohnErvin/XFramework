using HealthEssentials.Domain.Generics.Contracts.Responses.Ailment;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Ailment.Update;

public class UpdateAilmentEntityRequest : RequestBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? GroupGuid { get; set; }
    public int? SortOrder { get; set; }
}