using System;

namespace Wallets.Domain.Generic.Contracts.Responses;

public class WalletEntityResponse
{
    public Guid? Guid { get; set; }
    public bool? IsEnabled { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public short Type { get; set; }
    public long? CurrencyEntityId { get; set; }
    public decimal? MinTransfer { get; set; }
    public decimal? MaxTransfer { get; set; }
}