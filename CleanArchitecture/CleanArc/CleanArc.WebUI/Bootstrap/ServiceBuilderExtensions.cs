using Microsoft.Extensions.DependencyInjection;
using CleanArc.Common;
using System.Reflection;

namespace CleanArc.WebUI
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
