using XFramework.Domain.Generic.Contracts.Requests;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Logistic.Delete;

public class DeleteLogisticRiderRequest : RequestBase
{
    public Guid? Guid { get; set; }
}