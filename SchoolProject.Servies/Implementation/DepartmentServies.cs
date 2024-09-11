using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class DepartmentServies : IDepartmentServies
    {

        #region Fields
        public readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentServies(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        #endregion
        #region Handel Functions

        public async Task<List<Department>> GetDepartmentAsync()
        {
            return await _departmentRepository.GetDepartmentListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository
                                            .GetTableNoTracking()
                                            .Where(x => x.DID.Equals(id))
                                            .Include(x => x.Instructors)
                                            .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                                            .Include(x => x.Instructor)
                                            .SingleOrDefaultAsync();
            return department;


        }
        public async Task<bool> IsDepartmentIdExist(int id)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(id));

        }
        #endregion

    }
}
