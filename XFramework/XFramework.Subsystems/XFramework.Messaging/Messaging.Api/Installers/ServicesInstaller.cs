using Messaging.Api.SignalR;
using Messaging.Core.Interfaces;
using Messaging.Core.Services;
using XFramework.Integration.Interfaces;
using XFramework.Integration.Interfaces.Wrappers;
using XFramework.Integration.Services;

namespace Messaging.Api.Installers;

public class ServicesInstaller : IInstaller
{
    public virtual void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ICachingService, CachingService>();
        services.AddSingleton<IHelperService, HelperService>();
        services.AddSingleton<IJwtService, JwtService>();
        services.AddSingleton<ProcessMonitorService>();
    }
}