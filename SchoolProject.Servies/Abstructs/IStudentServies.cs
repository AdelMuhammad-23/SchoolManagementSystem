using SchoolProject.Data.Entities;

namespace SchoolProject.Servies.Abstructs
{
    public interface IStudentServies
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
    }
}
