using Microsoft.Extensions.DependencyInjection;
using DDDCqrsEs.Common;
using System.Reflection;

namespace DDDCqrsEs.WebUI
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterWebAPIServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(t => t.WithAttribute<MapServiceDependency>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
