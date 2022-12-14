using IdentityServer.Domain.Generic.Contracts.Requests.Get;
using IdentityServer.Domain.Generic.Contracts.Responses;

namespace IdentityServer.Core.DataAccess.Query.Entity.Identity.Roles;

public class GetRoleListQuery : GetRoleListRequest, IRequest<QueryResponse<List<IdentityRoleResponse>>>
{
}