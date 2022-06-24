﻿using HealthEssentials.Domain.Generics.Contracts.Requests.Patient;

namespace HealthEssentials.Core.DataAccess.Commands.Entity.Patient;

public class UpdatePatientCmd : UpdatePatientRequest, IRequest<CmdResponse<UpdatePatientCmd>>
{
    
}