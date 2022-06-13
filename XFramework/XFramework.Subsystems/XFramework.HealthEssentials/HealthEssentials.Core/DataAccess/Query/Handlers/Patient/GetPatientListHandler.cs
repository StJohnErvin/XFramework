﻿using HealthEssentials.Core.DataAccess.Query.Entity.Patient;
using HealthEssentials.Domain.Generics.Contracts.Responses.Patient;

namespace HealthEssentials.Core.DataAccess.Query.Handlers.Patient;

public class GetPatientListHandler : QueryBaseHandler, IRequestHandler<GetPatientListQuery, QueryResponse<List<PatientResponse>>>
{
    public GetPatientListHandler()
    {
        
    }
    public async Task<QueryResponse<List<PatientResponse>>> Handle(GetPatientListQuery request, CancellationToken cancellationToken)
    {
        var patient = await _dataLayer.HealthEssentialsContext.Patients
            .AsNoTracking()
            .OrderBy(i => i.CreatedAt)
            .Take(request.PageSize)
            .ToListAsync(CancellationToken.None);

        if (!patient.Any())
        {
            return new()
            {
                HttpStatusCode = HttpStatusCode.NoContent,
                Message = "No Patient Found",
                IsSuccess = true
            };
        }
        
        return new()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Message = "Patient Found",
            IsSuccess = true,
            Response = patient.Adapt<List<PatientResponse>>()
        };
    }
}