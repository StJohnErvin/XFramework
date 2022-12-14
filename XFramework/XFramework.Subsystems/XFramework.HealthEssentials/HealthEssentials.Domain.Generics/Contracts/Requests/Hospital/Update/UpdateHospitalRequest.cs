namespace HealthEssentials.Domain.Generics.Contracts.Requests.Hospital.Update;

public class UpdateHospitalRequest : RequestBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Remarks { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Logo { get; set; }
}