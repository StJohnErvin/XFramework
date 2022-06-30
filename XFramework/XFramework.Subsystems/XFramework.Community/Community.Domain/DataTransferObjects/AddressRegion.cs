﻿using System;
using System.Collections.Generic;

namespace Community.Domain.DataTransferObjects
{
    public partial class AddressRegion
    {
        public AddressRegion()
        {
            AddressProvinces = new HashSet<AddressProvince>();
            IdentityAddresses = new HashSet<IdentityAddress>();
        }

        public long Id { get; set; }
        public int PsgcCode { get; set; }
        public string? Description { get; set; }
        public long Code { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Guid { get; set; } = null!;
        public long? CountryId { get; set; }

        public virtual AddressCountry? Country { get; set; }
        public virtual ICollection<AddressProvince> AddressProvinces { get; set; }
        public virtual ICollection<IdentityAddress> IdentityAddresses { get; set; }
    }
}
