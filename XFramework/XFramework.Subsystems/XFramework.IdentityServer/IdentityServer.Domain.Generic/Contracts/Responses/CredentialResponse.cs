using Wallets.Domain.Generic.Contracts.Responses;

namespace IdentityServer.Domain.Generic.Contracts.Responses;

public class CredentialResponse
{
    public Guid? Guid { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public long? IdentityInfoId { get; set; }
    public string UserName { get; set; }
    public string UserAlias { get; set; }
    public short? LogInStatus { get; set; }
    public long ApplicationId { get; set; }
    public string Token { get; set; }

    public virtual IdentityResponse IdentityInfo { get; set; }
    public virtual List<IdentityRoleResponse> IdentityRoles { get; set; }
    public virtual List<ContactResponse> IdentityContacts { get; set; }
    public virtual List<WalletTransactionResponse> WalletTransactions { get; set; }
    public virtual List<WalletResponse> Wallets { get; set; }
    public virtual List<WithdrawalRequestResponse> WithdrawalRequests { get; set; }
}