using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Data;
using StoredProcedureEFCore;

namespace SchoolProject.Infrastructure.Repositories.Procedures
{
    public class DepartmentStudentCountProcRepository : IDepartmentStudentCountProcRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentStudentCountProcRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsDataAsync(DepartmentStudentCountProcParameter parameter)
        {
            var rows = new List<DepartmentStudentCountProc>();
            await _context.LoadStoredProc(nameof(DepartmentStudentCountProc))
                .AddParam(nameof(DepartmentStudentCountProcParameter.DID), parameter.DID)
                .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());
            return rows;
        }
    }
}
