using SchoolProject.Data.Entities;

namespace SchoolProject.Servies.Abstructs
{
    public interface IDepartmentServies
    {
        public Task<List<Department>> GetDepartmentAsync();
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<bool> IsDepartmentIdExist(int id);

    }
}
