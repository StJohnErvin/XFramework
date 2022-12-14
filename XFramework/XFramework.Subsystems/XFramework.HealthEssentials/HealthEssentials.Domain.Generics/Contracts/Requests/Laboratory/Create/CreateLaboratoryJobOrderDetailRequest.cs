namespace HealthEssentials.Domain.Generics.Contracts.Requests.Laboratory.Create;

public class CreateLaboratoryJobOrderDetailRequest : RequestBase
{
    public Guid? LaboratoryJobOrderGuid { get; set; }
    public Guid? LaboratoryServiceGuid { get; set; }
    public string? Quantity { get; set; }
    public string? Remarks { get; set; }
    public short? Status { get; set; }
}