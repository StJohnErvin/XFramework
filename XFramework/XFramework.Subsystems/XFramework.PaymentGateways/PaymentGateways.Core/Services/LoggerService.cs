using System;
using System.Threading.Tasks;
using PaymentGateways.Core.Interfaces;
using PaymentGateways.Domain.DataTransferObjects;

namespace PaymentGateways.Core.Services
{
    public class LoggerService : ILoggerWrapper
    {
        private readonly IDataLayer _dataLayer;

        public LoggerService(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        
        public async Task<Guid?> NewLog(string name, string message, string initiator, RequestServerBO requestServer, LogType logType = LogType.ApplicationServiceLog, GenericPriorityType priorityType = GenericPriorityType.Information)
        {
            var log = new TblLog()
            {
                ApplicationId = requestServer.ApplicationId,
                Initiator = initiator,
                Severity = (short) priorityType,
                Message = message,
                Name = name,
                Type = (short?) logType,
                Uuid = requestServer.Guid.ToString()
            };

            _dataLayer.TblLogs.Add(log);
            await _dataLayer.SaveChangesAsync();

            return requestServer.Guid;
        }

        public Task<Guid?> NewAuthorizationLog(AuthenticationState authenticationState, Guid cuid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLog(Guid guid, string title, string message, LogType logType = LogType.ApplicationServiceLog, GenericPriorityType priorityType = GenericPriorityType.Information)
        {
            throw new NotImplementedException();
        }
    }
}