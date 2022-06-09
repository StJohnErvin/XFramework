﻿using XFramework.Domain.Generic.Contracts.Requests;

namespace HealthEssentials.Domain.Generics.Contracts.Requests.Laboratory;

public class UpdateLaboratoryMemberRequest : RequestBase
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool? IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public long CredentialId { get; set; }
    public long LaboratoryId { get; set; }
    public string? Value { get; set; }
    public string Name { get; set; } = null!;
    public GenericStatusType Status { get; set; }
}