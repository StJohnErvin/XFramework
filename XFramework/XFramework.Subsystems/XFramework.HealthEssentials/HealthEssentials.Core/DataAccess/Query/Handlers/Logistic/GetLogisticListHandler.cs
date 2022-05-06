﻿using HealthEssentials.Core.DataAccess.Query.Entity.Logistic;
using HealthEssentials.Core.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HealthEssentials.Core.DataAccess.Query.Handlers.Logistic;

public class GetLogisticListHandler : QueryBaseHandler, IRequestHandler<GetLogisticListQuery, QueryResponse<List<LogisticResponse>>>
{
    public GetLogisticListHandler(IDataLayer dataLayer)
    {
        _dataLayer = dataLayer;
    }

    public async Task<QueryResponse<List<LogisticResponse>>> Handle(GetLogisticListQuery request, CancellationToken cancellationToken)
    {
        var Logistic = await _dataLayer.HealthEssentialsContext.Logistics
            .AsNoTracking()
            .Where(i => EF.Functions.Like(i.Name, $"%{request.SearchField}%"))
            .Take(request.PageSize)
            .OrderBy(i => i.Name)
            .ToListAsync(CancellationToken.None);

        if (!Logistic.Any())
        {
            return new()
            {
                HttpStatusCode = HttpStatusCode.NoContent,
                Message = "No Logistic Found",
                IsSuccess = true
            };
        }
        
        return new()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Message = "Logistic Found",
            IsSuccess = true,
            Response = Logistic.Adapt<List<LogisticResponse>>()
        };
    }
}