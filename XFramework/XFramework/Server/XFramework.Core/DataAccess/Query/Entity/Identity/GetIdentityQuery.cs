using System;
using IdentityServer.Domain.Generic.Contracts.Responses;
using MediatR;
using XFramework.Domain.Generic.BusinessObjects;

namespace XFramework.Core.DataAccess.Query.Entity.Identity
{
    public class GetIdentityQuery : IRequest<QueryResponse<IdentityResponse>>
    {
        public Guid Uid { get; set; }   
    }
}