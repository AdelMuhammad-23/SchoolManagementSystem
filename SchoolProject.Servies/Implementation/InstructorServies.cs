using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Functions;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class InstructorServies : IInstructorServies
    {
        #region Fileds
        private readonly ApplicationDbContext _dbContext;
        public readonly IInstructorRepository _instructorRepository;
        private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
        #endregion
        #region Constructors
        public InstructorServies(ApplicationDbContext dbContext,
                                 IInstructorFunctionsRepository instructorFunctionsRepository,
                                 IInstructorRepository instructorRepository)
        {
            _dbContext = dbContext;
            _instructorFunctionsRepository = instructorFunctionsRepository;
            _instructorRepository = instructorRepository;
        }
        #endregion

        #region Handle Functions
        public async Task<List<Instructor>> GetAllInstructors()
        {
            var instructorList = await _dbContext.Instructor.ToListAsync();
            return instructorList;
        }
        public async Task<decimal> GetSalarySummationOfInstructor()
        {
            decimal result = 0;
            result = _instructorFunctionsRepository.GetSalarySummationOfInstructor("select dbo.GetSalarySummation()");
            return result;
        }
        public async Task<string> DeleteInstructor(Instructor instructor)
        {
            var trancat = _dbContext.Database.BeginTransaction();
            try
            {
                await _instructorRepository.DeleteAsync(instructor);
                await trancat.CommitAsync();
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                await trancat.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<Instructor> GetInstructorById(int id)
        {
            return await _instructorRepository.GetByIdAsync(id);
        }
        #endregion
    }
}
