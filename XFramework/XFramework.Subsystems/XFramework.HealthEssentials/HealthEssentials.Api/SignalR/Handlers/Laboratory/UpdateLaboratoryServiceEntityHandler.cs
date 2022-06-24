﻿using HealthEssentials.Core.DataAccess.Commands.Entity.Laboratory;
using HealthEssentials.Core.DataAccess.Query.Entity.Laboratory;
using HealthEssentials.Domain.Generics.Contracts.Requests.Laboratory;

namespace HealthEssentials.Api.SignalR.Handlers.Laboratory;

public class UpdateLaboratoryServiceEntityHandler : BaseSignalRHandler, ISignalREventHandler
{
    public void Handle(HubConnection connection, IMediator mediator)
    {
        HandleRequestCmd<UpdateLaboratoryServiceEntityRequest, UpdateLaboratoryServiceEntityCmd>(connection, mediator);
    }
}