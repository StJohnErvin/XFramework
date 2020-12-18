﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using XFramework.Domain.DTO;

namespace XFramework.Core.DataAccess.Commands.Entity.Application
{
   public class GetAppInfoCmd : TblApplication, IRequest<bool>
    {

    }
}
