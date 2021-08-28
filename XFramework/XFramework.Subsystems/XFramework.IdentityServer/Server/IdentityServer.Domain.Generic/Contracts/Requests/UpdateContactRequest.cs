﻿using System;
using XFramework.Domain.Generic.Enums;

namespace IdentityServer.Domain.Generic.Contracts.Requests
{
    public class UpdateContactRequest : RequestBase
    {
        public GenericContactType ContactType { get; set; }
        public string Value { get; set; }
        public Guid Cuid { get; set; }
        public long Cid { get; set; }
    }
}