﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using XFramework.Domain.BO;

namespace XFramework.Core.DataAccess.Query.Entity.User
{
   public class AuthenticateUserQuery : UserAuthBO, IRequest<bool>
    {
      
    }
}
