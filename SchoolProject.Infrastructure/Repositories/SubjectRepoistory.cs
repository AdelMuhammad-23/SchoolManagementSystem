using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepoistory : GenericRepositoryAsync<Subject>, ISubjectRepoistory
    {

        #region Fields
        private readonly DbSet<Subject> _subjects;
        #endregion

        #region Constructors
        public SubjectRepoistory(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subjects = dbContext.Set<Subject>();
        }

        #endregion

        #region Handel Functions
        public async Task<List<Subject>> GetSubjectListAsync()
        {
            return await _subjects.ToListAsync();
        }
        #endregion
    }
}
