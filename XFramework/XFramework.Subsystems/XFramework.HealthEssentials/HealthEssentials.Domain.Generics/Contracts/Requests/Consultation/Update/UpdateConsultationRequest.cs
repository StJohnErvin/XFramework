using XFramework.Domain.Generic.Contracts.Requests;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Consultation.Update;

public class UpdateConsultationRequest : RequestBase
{
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? Description { get; set; }
    public Guid? EntityGuid { get; set; }
}