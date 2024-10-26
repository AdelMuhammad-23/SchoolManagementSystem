using SchoolProject.Data.Entities;

namespace SchoolProject.Servies.Abstructs
{
    public interface IDepartmentServies
    {
        public Task<List<Department>> GetDepartmentAsync();
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<string> AddDepartmentAsync(Department department);
        public Task<string> DeleteDepartmentAsync(Department department);
        public Task<string> updateDepartmentAsync(Department department);
        public Task<bool> IsDepartmentIdExist(int id);
        public Task<bool> IsDepartmentNameArabicIsExist(string departmentName);
        public Task<bool> IsDepartmentNameEnglishIsExist(string departmentName);
        public Task<bool> IsDepartmentNameEnglishIsExist(string departmentName, int id);
        public Task<bool> IsNameExistExcludeSelf(string departmentName, int id);


    }
}
