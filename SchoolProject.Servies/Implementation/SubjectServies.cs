using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class SubjectServies : ISubjectServies
    {
        #region Fields
        private readonly ISubjectRepoistory _subjectRepoistory;
        #endregion

        #region Constructors
        public SubjectServies(ISubjectRepoistory subjectRepoistory)
        {
            _subjectRepoistory = subjectRepoistory;
        }

        public async Task<string> AddSubjectsAsync(Subject subject)
        {
            await _subjectRepoistory.AddAsync(subject);
            return "Success";
        }

        public async Task<string> DeleteSubjectsAsync(Subject subject)
        {
            var trans = _subjectRepoistory.BeginTransaction();
            try
            {
                await _subjectRepoistory.DeleteAsync(subject);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditSubjectsAsync(Subject subject)
        {
            await _subjectRepoistory.UpdateAsync(subject);
            return "Success";
        }
        #endregion

        #region Handle Functions
        public async Task<List<Subject>> GetSubjectsAsync()
        {
            return await _subjectRepoistory.GetSubjectListAsync();
        }

        public async Task<Subject> GetSubjectsByIdAsync(int id)
        {
            var subject = await _subjectRepoistory.GetByIdAsync(id);
            return subject;

        }

        public async Task<bool> IsNameArabicExistExcludeSelf(string subjectName, int id)
        {
            var subject = await _subjectRepoistory.GetTableNoTracking().Where(x => x.SubjectNameAR.Equals(subjectName) && !x.SubID.Equals(id)).FirstOrDefaultAsync();
            if (subject == null)
                return false;
            return true;
        }
        public async Task<bool> IsNameEnglishExistExcludeSelf(string subjectName, int id)
        {
            var subject = await _subjectRepoistory.GetTableNoTracking().Where(x => x.SubjectNameAR.Equals(subjectName) && !x.SubID.Equals(id)).FirstOrDefaultAsync();
            if (subject == null)
                return false;
            return true;
        }
        #endregion



    }
}
