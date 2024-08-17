using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository :GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        public readonly DbSet<Student> _studnts;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _studnts = dbContext.Set<Student>();
        }

       
        #endregion

        #region Handel Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studnts.Include(dep => dep.Department).ToListAsync();
        }
        

        #endregion

    }
}
