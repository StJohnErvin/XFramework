using XFramework.Domain.Generic.Contracts.Requests;

namespace Wallets.Domain.Generic.Contracts.Requests.Update;

public class UpdateWalletRequest: TransactionRequestBase
{
    public Guid? CredentialGuid { get; set; }
    public Guid? WalletEntityGuid { get; set; }
    public decimal? Balance { get; set; }
}