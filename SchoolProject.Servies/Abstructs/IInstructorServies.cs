using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entities;

namespace SchoolProject.Servies.Abstructs
{
    public interface IInstructorServies
    {
        public Task<decimal> GetSalarySummationOfInstructor();
        public Task<List<Instructor>> GetAllInstructors();
        public Task<Instructor> GetInstructorById(int id);
        public Task<string> DeleteInstructor(Instructor instructor);
        public Task<string> AddInstructor(Instructor instructor, IFormFile instructorImage);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
    }
}
