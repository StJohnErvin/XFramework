namespace IdentityServer.Domain.Generic.Contracts.Responses;

public class IdentityContactGroupResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; }
    public string Guid { get; set; }
}