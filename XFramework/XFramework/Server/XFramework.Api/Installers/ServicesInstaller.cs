using XFramework.Core.Interfaces;
using XFramework.Core.Services;
using XFramework.Integration.Interfaces;
using XFramework.Integration.Services;

namespace XFramework.Api.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public virtual void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICachingService, CachingService>();
            services.AddSingleton<IHelperService, HelperService>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<ISignalRService, SignalRService>();
            services.AddSingleton<ProcessMonitorService>();
        }
    }
}