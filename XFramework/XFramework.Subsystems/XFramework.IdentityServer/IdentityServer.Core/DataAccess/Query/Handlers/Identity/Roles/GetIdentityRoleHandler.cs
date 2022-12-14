using IdentityServer.Core.DataAccess.Query.Entity.Identity.Roles;
using IdentityServer.Domain.Generic.Contracts.Responses;

namespace IdentityServer.Core.DataAccess.Query.Handlers.Identity.Roles;

public class GetIdentityRoleHandler : QueryBaseHandler, IRequestHandler<GetRoleQuery, QueryResponse<IdentityRoleResponse>>
{
    public GetIdentityRoleHandler(IDataLayer dataLayer)
    {
        _dataLayer = dataLayer;
    }
    
    public async Task<QueryResponse<IdentityRoleResponse>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dataLayer.IdentityCredentials
            .Include( i => i.IdentityInfo)
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(i => i.Guid == $"{request.Guid}", cancellationToken);
           
        if (entity == null)
        {
            return new ()
            {
                Message = $"Identity role with Guid {request.Guid} does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        return new ()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Response = entity.Adapt<IdentityRoleResponse>()
        };
    }
}