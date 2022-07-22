﻿using HealthEssentials.Domain.Generics.Contracts.Requests.Hospital.Update;

namespace HealthEssentials.Core.DataAccess.Commands.Entity.Hospital;

public class UpdateHospitalTagCmd : UpdateHospitalTagRequest, IRequest<CmdResponse<UpdateHospitalTagCmd>>
{
    
}