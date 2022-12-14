using HealthEssentials.Domain.Generics.Contracts.Responses.Pharmacy;
using XFramework.Domain.Generic.Contracts.Requests;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Pharmacy.Create;

public class CreatePharmacyJobOrderRequest : RequestBase
{
    public Guid? PharmacyLocationGuid { get; set; }
    public Guid? PatientGuid { get; set; }
    
    public string? ReferenceNumber { get; set; }
    public string? Remarks { get; set; }
    public TransactionStatus? Status { get; set; }
    public TransactionStatus? PaymentStatus { get; set; }
    public Guid? WalletTypeGuid { get; set; }
    public decimal? AmountDue { get; set; }
    public decimal? AmountPaid { get; set; }
    public decimal? Discount { get; set; }
    public decimal? DiscountType { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? PrescriptionNote { get; set; }
    public Guid? ScheduleGuid { get; set; }

    public List<PharmacyJobOrderMedicineResponse>? MedicineList { get; set; }
}