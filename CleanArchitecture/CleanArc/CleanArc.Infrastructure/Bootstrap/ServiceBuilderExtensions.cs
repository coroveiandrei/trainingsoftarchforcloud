using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CleanArc.Common;
using CleanArc.Infrastructure.RequestBehaviours;
using System.Reflection;

namespace CleanArc.Infrastructure.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterInfrastructureComponents(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(t => t.WithAttribute<MapServiceDependency>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CurrentUserBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
