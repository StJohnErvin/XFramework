﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using XFramework.Domain.BO;

namespace XFramework.Core.DataAccess.Commands.Entity.UserWallet
{
    public class CreateWalletTransactionCmd : WalletTransactionBO, IRequest<bool>
    {
    }
}