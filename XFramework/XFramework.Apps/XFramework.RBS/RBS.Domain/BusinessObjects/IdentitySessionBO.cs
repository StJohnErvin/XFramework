using RBS.Domain.Enums;
using System;
using System.Net;

namespace RBS.Domain.BusinessObjects
{
    public class IdentitySessionBO
    {
        public string Token { get; set; }
        public Guid Guid { get; set; }
        public DateTime LogonDateTime { get; set; }
        public TimeSpan MaxSessionTimeSpan { get; set; }
        public SessionState SessionState { get; set; }
        public IPAddress ClientIpAddress { get; set; }
        public RequestServerBO RequestServer { get; set; }
    }
}