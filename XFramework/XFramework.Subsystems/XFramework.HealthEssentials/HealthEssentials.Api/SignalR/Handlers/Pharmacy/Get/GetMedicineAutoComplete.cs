﻿using HealthEssentials.Core.DataAccess.Query.Entity.Medicine;
using HealthEssentials.Core.DataAccess.Query.Entity.Pharmacy;
using HealthEssentials.Domain.Generics.Contracts.Requests.Pharmacy.Get;
using HealthEssentials.Domain.Generics.Contracts.Responses.Pharmacy;

namespace HealthEssentials.Api.SignalR.Handlers.Pharmacy.Get;

public class GetMedicineAutoCompleteHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestQuery<GetMedicineAutoCompleteRequest, GetMedicineAutoCompleteQuery, List<string>>(connection, mediator);
    }
}