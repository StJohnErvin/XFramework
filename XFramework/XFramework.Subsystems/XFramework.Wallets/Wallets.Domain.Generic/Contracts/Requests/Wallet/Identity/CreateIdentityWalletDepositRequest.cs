﻿using XFramework.Domain.Generic.Contracts.Requests;

namespace Wallets.Domain.Generic.Contracts.Requests.Wallet.Identity
{
    public class CreateIdentityWalletDepositRequest : RequestBase
    {
        public string Cuid { get; set; }
        public string GatewayName { get; set; }
        public string WalletTypeCode { get; set; }
        public decimal? Amount { get; set; }
        public string Remarks { get; set; }
    }
}