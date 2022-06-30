﻿using System.Text.Json;
using HealthEssentials.Core.DataAccess.Query.Entity.Laboratory;
using HealthEssentials.Domain.Generics.Contracts.Responses.Storage;
using IdentityServer.Domain.Generic.Contracts.Responses;
using IdentityServer.Domain.Generic.Contracts.Responses.Address;

namespace HealthEssentials.Core.DataAccess.Query.Handlers.Laboratory;

public class GetLaboratoryLocationHandler : QueryBaseHandler, IRequestHandler<GetLaboratoryLocationQuery, QueryResponse<LaboratoryLocationResponse>>
{
    public GetLaboratoryLocationHandler(IDataLayer dataLayer, IDataLayer dataLayer2, IDataLayer dataLayer3, IDataLayer dataLayer4, IDataLayer dataLayer5)
    {
        _dataLayer2 = dataLayer2;
        _dataLayer3 = dataLayer3;
        _dataLayer4 = dataLayer4;
        _dataLayer5 = dataLayer5;
        _dataLayer = dataLayer;
    }
    
    public async Task<QueryResponse<LaboratoryLocationResponse>> Handle(GetLaboratoryLocationQuery request, CancellationToken cancellationToken)
    {
        var laboratoryLocation = await _dataLayer.HealthEssentialsContext.LaboratoryLocations
            .Include(i => i.LaboratoryServices)
            .Include(i => i.LaboratoryMembers)
            .Include(i => i.LaboratoryLocationTags)
            .Include(i => i.Laboratory)
            .Where(i => i.Guid == $"{request.Guid}")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(CancellationToken.None);

        if (laboratoryLocation is null)
        {
            return new()
            {
                HttpStatusCode = HttpStatusCode.NoContent,
                Message = $"Laboratory with the Guid '{request.Guid}' does not exist",
                IsSuccess = true
            };
        }
        
        var response = laboratoryLocation.Adapt<LaboratoryLocationResponse>();

        await GetFilesList(response);
        await GetMemberList(response);
        await GetBranchAddressData(response);

        return new()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Message = "Laboratory Found",
            IsSuccess = true,
            Response = response
        };        
    }

    private async Task GetFilesList(LaboratoryLocationResponse response)
    {
        response.Files = _dataLayer.XnelSystemsContext.StorageFiles
            .Where(i => i.IdentifierGuid == $"{response.Guid}" || i.IdentifierGuid == $"{response.Laboratory.Guid}")
            .AsNoTracking()
            .ToList()
            .Adapt<List<StorageFileResponse>>();
    }
    private async Task GetBranchAddressData(LaboratoryLocationResponse response)
    {
        var countryId = response.Country;
        var regionId = response.Region;
        var provinceId = response.Province;
        var cityId = response.City;
        var barangayId = response.Barangay;

        var countryNavigation = _dataLayer.XnelSystemsContext.AddressCountries
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == countryId, CancellationToken.None);
        var regionNavigation = _dataLayer2.XnelSystemsContext.AddressRegions
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == regionId, CancellationToken.None);
        var provinceNavigation = _dataLayer3.XnelSystemsContext.AddressProvinces
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == provinceId, CancellationToken.None);
        var cityNavigation = _dataLayer4.XnelSystemsContext.AddressCities
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == cityId, CancellationToken.None);
        var barangayNavigation = _dataLayer5.XnelSystemsContext.AddressBarangays
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == barangayId, CancellationToken.None);

        await Task.WhenAll(countryNavigation, regionNavigation, provinceNavigation, cityNavigation, barangayNavigation);

        response.CountryNavigation = countryNavigation.Result?.Adapt<AddressCountryResponse>();
        response.RegionNavigation = regionNavigation.Result?.Adapt<AddressRegionResponse>();
        response.ProvinceNavigation = provinceNavigation.Result?.Adapt<AddressProvinceResponse>();
        response.CityNavigation = cityNavigation.Result?.Adapt<AddressCityResponse>();
        response.BarangayNavigation = barangayNavigation?.Result.Adapt<AddressBarangayResponse>();
    }

    private async Task GetMemberList(LaboratoryLocationResponse response)
    {
        for (var index = 0; index < response.LaboratoryMembers.Count; index++)
        {
            var o = index; 
            response.LaboratoryMembers[o].Credential = _dataLayer.XnelSystemsContext.IdentityCredentials
                .Include(i => i.IdentityInfo)
                .Include(i => i.IdentityContacts)
                .ThenInclude(i => i.Entity)
                .Where(i => i.Id == response.LaboratoryMembers[o].CredentialId)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefault()?
                .Adapt<CredentialResponse>();
        }
    }
    
}