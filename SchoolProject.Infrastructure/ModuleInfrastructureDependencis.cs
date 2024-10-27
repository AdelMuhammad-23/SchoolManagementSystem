using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Abstracts.Veiws;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Repositories;
using SchoolProject.Infrastructure.Repositories.Procedures;
using SchoolProject.Infrastructure.Repositories.Views;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependencis
    {
        public static IServiceCollection AddInfrastructureDependencis(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepoistory, SubjectRepoistory>();
            services.AddTransient<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            //Views
            services.AddTransient<IViewDepartmentRepository<ViewDepartment>, ViewDepartmentRepository>();

            //Procedures
            services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();

            return services;
        }
    }
}
