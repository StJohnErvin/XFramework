using MediatR;
using System.Collections.Generic;
using RBS.Domain.BusinessObjects;
using RBS.Domain.Contracts;

namespace RBS.Core.DataAccess.Query.Entity.Application
{
    public class GetAppAppListQuery : QueryBaseEntity, IRequest<QueryResponseBO<List<GetApplicationListContract>>>
    {

    }
}