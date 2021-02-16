﻿using System;
using IdentityServer.Domain.BusinessObjects;
using MediatR;

namespace IdentityServer.Core.DataAccess.Commands.Entity.Identity.Authorization
{
    public class DeleteAuthorizeIdentityCmd : CommandBaseEntity, IRequest<CmdResponseBO<DeleteAuthorizeIdentityCmd>>
    {
        public Guid Uid { get; set; }
        
        public string Username { get; set; }
        
    }
}