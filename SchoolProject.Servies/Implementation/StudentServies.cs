using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class StudentServies : IStudentServies
    {
        #region Fields
        public readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructor
        public StudentServies(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region Handel Functions
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                            .Include(x => x.Department)
                                            .Where(x => x.StudID.Equals(id))
                                            .FirstOrDefault();
            return student;
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {

            //Added Student
            await _studentRepository.AddAsync(student);
            return "Success";

        }

        public async Task<bool> IsNameExist(string name)
        {
            //Check if the name is Exist or not
            var studentName = _studentRepository.GetTableNoTracking()
                                                .Where(st => st.Name.Equals(name))
                                                .FirstOrDefault();
            if (studentName == null)
                return false;

            return true;
        }

        public async Task<bool> IsNameExistSelf(string name, int id)
        {
            //Check if the name is Exist or not
            var studentName = await _studentRepository.GetTableNoTracking()
                                                .Where(st => st.Name.Equals(name) & st.StudID != id)
                                                .FirstOrDefaultAsync();
            if (studentName == null)
                return false;

            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";

        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }


        }
        #endregion
    }
}
