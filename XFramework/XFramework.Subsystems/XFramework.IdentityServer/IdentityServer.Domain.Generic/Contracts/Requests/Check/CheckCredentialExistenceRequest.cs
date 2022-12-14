using XFramework.Domain.Generic.Contracts.Requests;

namespace IdentityServer.Domain.Generic.Contracts.Requests.Check;

public class CheckCredentialExistenceRequest : RequestBase
{
    public string UserName { get; set; }
    public Guid? Guid { get; set; }
    public string Password { get; set; }
    public List<Guid?> RoleList { get; set; }
}