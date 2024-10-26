using SchoolProject.Data.Entities;

namespace SchoolProject.Servies.Abstructs
{
    public interface ISubjectServies
    {
        public Task<List<Subject>> GetSubjectsAsync();
        public Task<Subject> GetSubjectsByIdAsync(int id);
        public Task<string> AddSubjectsAsync(Subject subject);
        public Task<string> EditSubjectsAsync(Subject subject);
        public Task<string> DeleteSubjectsAsync(Subject subject);
        public Task<bool> IsNameArabicExistExcludeSelf(string subjectName, int id);
        public Task<bool> IsNameEnglishExistExcludeSelf(string subjectName, int id);
    }
}
