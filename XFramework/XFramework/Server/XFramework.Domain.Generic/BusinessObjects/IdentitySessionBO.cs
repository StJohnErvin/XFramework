using System;
using System.Net;
using XFramework.Domain.Generic.Enums;

namespace XFramework.Domain.Generic.BusinessObjects
{
    public class IdentitySessionBO
    {
        public string Token { get; set; }
        public Guid Guid { get; set; }
        public DateTime LogonDateTime { get; set; }
        public TimeSpan MaxSessionTimeSpan { get; set; }
        public CurrentSessionState SessionState { get; set; }
        public IPAddress ClientIpAddress { get; set; }
        public RequestServerBO RequestServer { get; set; }
    }
}