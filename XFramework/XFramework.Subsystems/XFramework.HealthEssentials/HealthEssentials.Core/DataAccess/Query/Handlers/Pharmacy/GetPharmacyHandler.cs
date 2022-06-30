﻿using HealthEssentials.Core.DataAccess.Query.Entity.Pharmacy;
using HealthEssentials.Domain.Generics.Contracts.Responses.Storage;
using IdentityServer.Domain.Generic.Contracts.Responses;
using IdentityServer.Domain.Generic.Contracts.Responses.Address;

namespace HealthEssentials.Core.DataAccess.Query.Handlers.Pharmacy;

public class GetPharmacyHandler : QueryBaseHandler, IRequestHandler<GetPharmacyQuery, QueryResponse<PharmacyResponse>>
{
    public GetPharmacyHandler(IDataLayer dataLayer, IDataLayer dataLayer2, IDataLayer dataLayer3, IDataLayer dataLayer4, IDataLayer dataLayer5)
    {
        _dataLayer2 = dataLayer2;
        _dataLayer3 = dataLayer3;
        _dataLayer4 = dataLayer4;
        _dataLayer5 = dataLayer5;
        _dataLayer = dataLayer;
    }

    public async Task<QueryResponse<PharmacyResponse>> Handle(GetPharmacyQuery request, CancellationToken cancellationToken)
    {
        var pharmacy = await _dataLayer.HealthEssentialsContext.Pharmacies
            .Include(i => i.Entity)
            .Include(i => i.PharmacyLocations)
            .Include(i => i.PharmacyMembers)
            .Where(i => i.Guid == $"{request.Guid}")
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(CancellationToken.None);

        if (pharmacy is null)
        {
            return new()
            {
                HttpStatusCode = HttpStatusCode.NoContent,
                Message = $"No pharmacy found with Guid: {request.Guid}",
                IsSuccess = true
            };
        }
        
        var response = pharmacy.Adapt<PharmacyResponse>();

        await GetMemberList(response);
        await GetBranchList(response);

        return new()
        {
            HttpStatusCode = HttpStatusCode.Accepted,
            Message = "Pharmacy found",
            IsSuccess = true,
            Response = response
        };        
    }

    private async Task GetBranchList(PharmacyResponse response)
    {
        for (var index = 0; index < response.PharmacyLocations.Count; index++)
        {
            var countryId = response.PharmacyLocations[index].Country;
            var regionId = response.PharmacyLocations[index].Region;
            var provinceId = response.PharmacyLocations[index].Province;
            var cityId = response.PharmacyLocations[index].City;
            var barangayId = response.PharmacyLocations[index].Barangay;

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

            response.PharmacyLocations[index].CountryNavigation =
                countryNavigation.Result?.Adapt<AddressCountryResponse>();
            response.PharmacyLocations[index].RegionNavigation = regionNavigation.Result?.Adapt<AddressRegionResponse>();
            response.PharmacyLocations[index].ProvinceNavigation =
                provinceNavigation.Result?.Adapt<AddressProvinceResponse>();
            response.PharmacyLocations[index].CityNavigation = cityNavigation.Result?.Adapt<AddressCityResponse>();
            response.PharmacyLocations[index].BarangayNavigation =
                barangayNavigation?.Result.Adapt<AddressBarangayResponse>();
        }
    }

    private async Task GetMemberList(PharmacyResponse response)
    {
        for (var index = 0; index < response.PharmacyMembers.Count; index++)
        {
            response.PharmacyMembers[index].Credential = _dataLayer.XnelSystemsContext.IdentityCredentials
                .AsNoTracking()
                .Include(i => i.IdentityInfo)
                .Include(i => i.IdentityContacts)
                .ThenInclude(i => i.Entity)
                .AsSplitQuery()
                .Where(i => i.Id == response.PharmacyMembers[index].CredentialId)
                .FirstOrDefault()?
                .Adapt<CredentialResponse>();
        }
    }

}