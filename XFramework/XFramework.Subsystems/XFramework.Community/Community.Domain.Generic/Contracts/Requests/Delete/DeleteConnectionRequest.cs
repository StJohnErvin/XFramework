using XFramework.Domain.Generic.Contracts.Requests;

namespace Community.Domain.Generic.Contracts.Requests.Delete;

public class DeleteConnectionRequest : RequestBase
{
    public Guid? Guid { get; set; }
}