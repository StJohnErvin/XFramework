using System.Reflection;
using FluentValidation;
using HealthEssentials.Core.DataAccess.Commands.Handlers;
using HealthEssentials.Core.PipelineBehaviors;

namespace HealthEssentials.Api.Installers;

public class ExternalDependencyInstaller : IInstaller
{
    public virtual void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        // MediatR
        services.AddMediatR(typeof(CommandBaseHandler).GetTypeInfo().Assembly);
            
        // FluentValidation
        services.AddValidatorsFromAssembly(typeof(CommandBaseHandler).GetTypeInfo().Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BasePipelineBehavior<,>));
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
    }
}