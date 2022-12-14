using HealthEssentials.Core.DataAccess.Commands.Entity.Pharmacy;

namespace HealthEssentials.Core.DataAccess.Commands.Handlers.Pharmacy;

public class UpdatePharmacyLocationHandler : CommandBaseHandler, IRequestHandler<UpdatePharmacyLocationCmd, CmdResponse<UpdatePharmacyLocationCmd>>
{
    public UpdatePharmacyLocationHandler(IDataLayer dataLayer)
    {
        _dataLayer = dataLayer;
    }
    
    public async Task<CmdResponse<UpdatePharmacyLocationCmd>> Handle(UpdatePharmacyLocationCmd request, CancellationToken cancellationToken)
    {
        var existingPharmacyLocation = await _dataLayer.HealthEssentialsContext.PharmacyLocations.FirstOrDefaultAsync(x => x.Guid == $"{request.Guid}", CancellationToken.None);
        if (existingPharmacyLocation == null)
        {
            return new ()
            {
                Message = $"Pharmacy Location with Guid {request.Guid} does not exist",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        var updatedPharmacyLocation = request.Adapt(existingPharmacyLocation);

        if (request.PharmacyGuid is not null)
        {
            var pharmacy = await _dataLayer.HealthEssentialsContext.Pharmacies.FirstOrDefaultAsync(x => x.Guid == $"{request.PharmacyGuid}", CancellationToken.None);
            if (pharmacy is null)
            {
                return new ()
                {
                    Message = $"Pharmacy with Guid {request.Guid} does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }
            updatedPharmacyLocation.Pharmacy = pharmacy;
        }

        if (request.BarangayGuid is not null)
        {
            var barangay = await _dataLayer.XnelSystemsContext.AddressBarangays.FirstOrDefaultAsync(x => x.Guid == $"{request.BarangayGuid}", CancellationToken.None);
            if (barangay is null)
            {
                return new ()
                {
                    Message = $"Barangay with Guid {request.BarangayGuid} does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }
            updatedPharmacyLocation.BarangayId = barangay.Id;
        }

        if (request.CityGuid is not null)
        {
            var city = await _dataLayer.XnelSystemsContext.AddressCities.FirstOrDefaultAsync(x => x.Guid == $"{request.CityGuid}", CancellationToken.None);
            if (city is null)
            {
                return new ()
                {
                    Message = $"City with Guid {request.CityGuid} does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }
            updatedPharmacyLocation.CityId = city.Id;
        }

        if (request.RegionGuid is not null)
        {
            var region = await _dataLayer.XnelSystemsContext.AddressRegions.FirstOrDefaultAsync(x => x.Guid == $"{request.RegionGuid}", CancellationToken.None);
            if (region is null)
            {
                return new ()
                {
                    Message = $"Region with Guid {request.RegionGuid} does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }
            updatedPharmacyLocation.RegionId = region.Id;
        }

        if (request.ProvinceGuid is not null)
        {
            var province = await _dataLayer.XnelSystemsContext.AddressProvinces.FirstOrDefaultAsync(x => x.Guid == $"{request.ProvinceGuid}", CancellationToken.None);
            if (province is null)
            {
                return new ()
                {
                    Message = $"Province with Guid {request.ProvinceGuid} does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }
            updatedPharmacyLocation.ProvinceId = province.Id;
        }


        if (request.CountryGuid is not null)
        {
            var country = await _dataLayer.XnelSystemsContext.AddressCountries.FirstOrDefaultAsync(x => x.Guid == $"{request.CountryGuid}", CancellationToken.None);
            if (country is null)
            {
                return new ()
                {
                    Message = $"Country with Guid {request.CountryGuid} does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }
            updatedPharmacyLocation.CountryId = country.Id;
        }

        _dataLayer.HealthEssentialsContext.Update(updatedPharmacyLocation);
        await _dataLayer.HealthEssentialsContext.SaveChangesAsync(CancellationToken.None);
        
        return new ()
        {
            Message = $"Pharmacy Location with Guid {request.Guid} updated successfully",
            HttpStatusCode = HttpStatusCode.Accepted
        };
    }
}