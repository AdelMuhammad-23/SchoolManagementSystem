using SchoolProject.Data.Entities.Procedures;

namespace SchoolProject.Infrastructure.Abstracts.Procedures
{
    public interface IDepartmentStudentCountProcRepository
    {
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsDataAsync(DepartmentStudentCountProcParameter parameter);
    }
}
