using IdentityServer.Core.DataAccess.Query.Entity.Identity.Contacts;
using IdentityServer.Domain.Generic.Contracts.Responses;

namespace IdentityServer.Core.DataAccess.Query.Handlers.Identity.Contacts;

public class GetContactListHandler : QueryBaseHandler ,IRequestHandler<GetContactListQuery, QueryResponse<List<ContactResponse>>>
{
    public GetContactListHandler(IDataLayer dataLayer)
    {
        _dataLayer = dataLayer;
    }
    
    public async Task<QueryResponse<List<ContactResponse>>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
    {
        var credential = await _dataLayer.IdentityCredentials
            .Include(i => i.IdentityInfo)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Guid == $"{request.CredentialGuid}", cancellationToken);
            
        if (credential == null)
        {
            return new()
            {
                Message = $"Credentials does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        
        var entity = await _dataLayer.IdentityContacts
            .Where(i => i.UserCredentialId == credential.Id)
            .Include( i => i.Entity)
            .AsNoTracking()
            .AsSplitQuery()
            .ToListAsync(cancellationToken);
           
        if (!entity.Any())
        {
            return new ()
            {
                Message = $"No contacts exists",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        return new ()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Response = entity.Adapt<List<ContactResponse>>()
        };
    }
}