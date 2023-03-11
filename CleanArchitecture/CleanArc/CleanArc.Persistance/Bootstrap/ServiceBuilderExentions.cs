using Microsoft.Extensions.DependencyInjection;
using CleanArc.Common;
using System.Reflection;

namespace CleanArc.Persistance.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(t=> t.WithAttribute<MapServiceDependency>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        }
    }
}
