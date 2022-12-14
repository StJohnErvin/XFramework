using IdentityServer.Domain.Generic.Contracts.Responses.Address;
using XFramework.Domain.Generic.Enums;

namespace IdentityServer.Domain.Generic.Contracts.Responses;

public class IdentityResponse
{
    public Guid? Guid { get; set; }
    public DateTime CreatedAt { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public long? ModifiedBy { get; set; }
    public string Avatar { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string IdentityName { get; set; }
    public string IdentityDescription { get; set; }
    public DateTime Dob { get; set; }
    public Gender Gender { get; set; }
    public bool IsVerified { get; set; }
    public CivilStatus CivilStatus { get; set; }
    
    public List<IdentityAddressResponse> IdentityAddresses { get; set; }

}