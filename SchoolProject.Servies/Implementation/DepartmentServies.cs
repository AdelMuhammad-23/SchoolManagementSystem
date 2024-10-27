using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Abstracts.Veiws;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class DepartmentServies : IDepartmentServies
    {

        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IViewDepartmentRepository<ViewDepartment> _viewDepartmentRepository;
        private readonly IDepartmentStudentCountProcRepository _departmentStudentCountProcRepository;
        #endregion

        #region Constructor
        public DepartmentServies(IDepartmentRepository departmentRepository,
                                IViewDepartmentRepository<ViewDepartment> viewDepartmentRepository,
                                IDepartmentStudentCountProcRepository departmentStudentCountProcRepository)
        {
            _departmentRepository = departmentRepository;
            _viewDepartmentRepository = viewDepartmentRepository;
            _departmentStudentCountProcRepository = departmentStudentCountProcRepository;
        }

        public async Task<string> AddDepartmentAsync(Department department)
        {
            var addDepartment = await _departmentRepository.AddAsync(department);

            return "Success";
        }

        public async Task<string> DeleteDepartmentAsync(Department department)
        {
            var trans = _departmentRepository.BeginTransaction();
            try
            {
                await _departmentRepository.DeleteAsync(department);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
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

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsDataAsync(DepartmentStudentCountProcParameter parameter)
        {
            return await _departmentStudentCountProcRepository.GetDepartmentStudentCountProcsDataAsync(parameter);
        }

        public async Task<List<ViewDepartment>> GetViewDepartmentDataAsync()
        {
            return await _viewDepartmentRepository.GetTableAsTracking().ToListAsync();
        }

        public async Task<bool> IsDepartmentIdExist(int id)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(id));

        }

        public async Task<bool> IsDepartmentNameArabicIsExist(string departmentName)
        {
            return await _departmentRepository.GetTableAsTracking().AnyAsync(n => n.DNameAr.Equals(departmentName));
        }
        public async Task<bool> IsDepartmentNameEnglishIsExist(string departmentName)
        {
            return await _departmentRepository.GetTableAsTracking().AnyAsync(n => n.DNameEn.Equals(departmentName));
        }

        public async Task<bool> IsDepartmentNameEnglishIsExist(string departmentName, int id)
        {

            //Check if the name is Exist Or not
            var student = await _departmentRepository.GetTableNoTracking().Where(x => x.DNameAr.Equals(departmentName) && !x.DID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string departmentName, int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.DNameEn.Equals(departmentName) && !x.DID.Equals(id)).FirstOrDefaultAsync();
            if (department == null) return false;
            return true;
        }

        public async Task<string> updateDepartmentAsync(Department department)
        {
            await _departmentRepository.UpdateAsync(department);
            return "Success";
        }
        #endregion

    }
}
