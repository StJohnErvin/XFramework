

using HealthEssentials.Domain.Generics.Contracts.Responses.Consultation;

namespace HealthEssentials.Domain.Generics.Contracts.Responses.Patient;

public class PatientAilmentDetailResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public string? DoctorName { get; set; }
    public short? Status { get; set; }
    public string? Remarks { get; set; }
    public Guid? Guid { get; set; }
    
    public ConsultationJobOrderResponse? ConsultationJobOrder { get; set; }
    public PatientAilmentResponse? PatientAilment { get; set; }
}