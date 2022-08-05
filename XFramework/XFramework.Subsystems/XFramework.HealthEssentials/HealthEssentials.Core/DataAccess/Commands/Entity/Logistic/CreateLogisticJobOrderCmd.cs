﻿using HealthEssentials.Domain.Generics.Contracts.Requests.Logistic.Create;

namespace HealthEssentials.Core.DataAccess.Commands.Entity.Logistic;

public class CreateLogisticJobOrderCmd : CreateLogisticJobOrderRequest, IRequest<CmdResponse<CreateLogisticJobOrderCmd>>
{
    
}