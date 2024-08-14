using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencis
    {
        public static IServiceCollection AddCoreDependencis(this IServiceCollection services)
        {
            // Configuration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;

        }

    }
}
