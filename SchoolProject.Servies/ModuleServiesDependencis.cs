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
                services.AddTransient<IDepartmentServies, DepartmentServies>();
                services.AddTransient<IInstructorServies, InstructorServies>();
                services.AddTransient<ISubjectServies, SubjectServies>();
                services.AddTransient<IAuthenticationServies, AuthenticationServies>();
                services.AddTransient<IAuthorizationServies, AuthorizationServies>();

                return services;
            }
        }
    }
}
