using IdentityServer.Domain.Generic.Enums;
using XFramework.Domain.Generic.Contracts.Requests;

namespace IdentityServer.Domain.Generic.Contracts.Requests.Create;

public class CreateCredentialRequest : TransactionRequestBase
{
    public string UserAlias { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string Password { get; set; }
    public List<Guid?> RoleList { get; set; }
    public Guid? IdentityGuid { get; set; }
    public Guid? Guid { get; set; }
}