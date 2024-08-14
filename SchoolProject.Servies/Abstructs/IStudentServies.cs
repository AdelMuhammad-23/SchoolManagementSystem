using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Servies.Abstructs
{
    public interface IStudentServies
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id );
        public Task<string> AddStudentAsync(Student student);
    }
}
