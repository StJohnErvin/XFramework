using System;

namespace RBS.Domain.Generic.Contracts.Requests
{
    public class CreateCredentialRequest : RequestBase
    {
        public string UserAlias { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string PasswordString { get; set; }
        public Guid Uid { get; set; }
    }
}