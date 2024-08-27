using SchoolProject.Data.Entities;

namespace SchoolProject.Servies.Abstructs
{
    public interface IStudentServies
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdWithIncludeAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);

        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistSelf(string name, int id);
    }
}
