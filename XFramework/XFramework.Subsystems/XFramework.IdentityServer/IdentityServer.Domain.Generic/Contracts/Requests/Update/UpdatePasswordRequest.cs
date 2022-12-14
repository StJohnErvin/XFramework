using XFramework.Domain.Generic.Contracts.Requests;

namespace IdentityServer.Domain.Generic.Contracts.Requests.Update;

public class UpdatePasswordRequest : TransactionRequestBase
{
    public Guid? CredentialGuid { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}