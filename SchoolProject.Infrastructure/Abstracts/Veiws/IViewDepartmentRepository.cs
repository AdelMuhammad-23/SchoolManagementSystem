using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts.Veiws
{
    public interface IViewDepartmentRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
    }
}
