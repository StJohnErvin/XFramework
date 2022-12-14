namespace HealthEssentials.Domain.Generics.Contracts.Requests.Logistic.Create;

public class CreateLogisticJobOrderLocationRequest : RequestBase
{
    public Guid? LogisticJobOrderGuid { get; set; }
    public short Status { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? UnitNumber { get; set; }
    public string? Street { get; set; }
    public string? Building { get; set; }
    public Guid? BarangayGuid { get; set; }
    public Guid? CityGuid { get; set; }
    public string? Subdivision { get; set; }
    public Guid? RegionGuid { get; set; }
    public bool? MainAddress { get; set; }
    public Guid? ProvinceGuid { get; set; }
    public Guid? CountryGuid { get; set; }
    public short Priority { get; set; }
}