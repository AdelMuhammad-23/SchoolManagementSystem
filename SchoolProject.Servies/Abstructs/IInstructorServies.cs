using SchoolProject.Data.Entities;

namespace SchoolProject.Servies.Abstructs
{
    public interface IInstructorServies
    {
        public Task<decimal> GetSalarySummationOfInstructor();
        public Task<List<Instructor>> GetAllInstructors();
        public Task<Instructor> GetInstructorById(int id);
        public Task<string> DeleteInstructor(Instructor instructor);
    }
}
