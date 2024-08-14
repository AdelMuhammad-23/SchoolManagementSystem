using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Servies.Abstructs;
using SchoolProject.Servies.Implementation;

namespace SchoolProject.Servies
{

    public static class ModuleServiesDependencis
    {
        public static IServiceCollection AddServiesDependencis(this IServiceCollection services)
        {
            {
                services.AddTransient<IStudentServies, StudentServies>();
                return services;
            }
        }
    }
}
