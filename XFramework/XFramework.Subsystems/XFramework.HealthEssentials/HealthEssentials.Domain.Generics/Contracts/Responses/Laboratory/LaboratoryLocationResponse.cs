﻿using System.Text.Json.Serialization;
using HealthEssentials.Domain.Generics.Contracts.Responses.Storage;
using IdentityServer.Domain.Generic.Contracts.Responses.Address;

namespace HealthEssentials.Domain.Generics.Contracts.Responses.Laboratory;

public class LaboratoryLocationResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public long LaboratoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? UnitNumber { get; set; }
    public string? Street { get; set; }
    public string? Building { get; set; }
    public long? BarangayId { get; set; }
    public long? CityId { get; set; }
    public string? Subdivision { get; set; }
    public long? RegionId { get; set; }
    public bool? MainAddress { get; set; }
    public long? ProvinceId { get; set; }
    public long? CountryId { get; set; }
    public string Guid { get; set; } = null!;
    public int? Status { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? AlternativePhone { get; set; }

    public LaboratoryResponse? Laboratory { get; set; }

}