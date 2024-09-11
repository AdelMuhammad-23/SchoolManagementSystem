using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

namespace SchoolProject.Servies.Abstructs
{
    public interface IStudentServies
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<Student> GetByIDAsync(int id);
        public Task<Student> GetStudentByIDWithIncludeAsync(int id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> GetStudentsByDepartmentIdQuerable(int DID);
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
        public Task<bool> IsNameExistExcludeSelf(string namr, int id);



    }
}

