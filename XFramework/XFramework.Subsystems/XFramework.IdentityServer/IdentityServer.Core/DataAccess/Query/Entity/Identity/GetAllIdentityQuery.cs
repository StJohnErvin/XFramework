using IdentityServer.Domain.Generic.Contracts.Responses;

namespace IdentityServer.Core.DataAccess.Query.Entity.Identity;

public class GetAllIdentityQuery : QueryBaseEntity, IRequest<QueryResponse<List<IdentityResponse>>>
{
        
}