﻿using XFramework.Domain.Generic.Contracts.Requests;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Doctor;

public class CreateDoctorConsultationRequest : RequestBase
{
    public Guid? ConsultationGuid { get; set; }
    public Guid? DoctorGuid { get; set; }
}