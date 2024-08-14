using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Servies.Abstructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                            .Include(x=> x.Department)
                                            .Where(x=>x.StudID.Equals(id))
                                            .FirstOrDefault();
            return student;
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            //Check if the name is Exist or not
           var studenName = _studentRepository.GetTableAsTracking().Where(st=>st.Name.Equals(student.Name)).FirstOrDefault();
            if (studenName != null) return "Exist";
            //Added Student
            await _studentRepository.AddAsync(student);
            return "Success";

        }
        #endregion
    }
}
