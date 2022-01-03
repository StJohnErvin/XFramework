﻿using XFramework.Domain.Generic.Contracts.Requests;

namespace Wallets.Domain.Generic.Contracts.Requests.Wallet.Identity
{
    public class DeleteIdentityWalletRequest : RequestBase
    {
        public string Cuid { get; set; }
        public long? WalletTypeId { get; set; }
        
    }
}