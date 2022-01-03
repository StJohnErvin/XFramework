﻿using MediatR;
using XFramework.Domain.Generic.BusinessObjects;

namespace Wallets.Core.DataAccess.Commands.Entity.Wallets.Identity
{
    public class TransferIdentityWalletCmd : IRequest<CmdResponseBO<TransferIdentityWalletCmd>>
    {
        public long? FromWalletTypeId { get; set; }
        public long? ToWalletTypeId { get; set; }
        public decimal? Amount { get; set; }
        public long? FromUserCuid { get; set; }
        public long? ToUserCuid { get; set; }
    }
}