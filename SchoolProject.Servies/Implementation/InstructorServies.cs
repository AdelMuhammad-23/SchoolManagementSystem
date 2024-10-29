using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts.Functions;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class InstructorServies : IInstructorServies
    {
        #region Fileds
        private readonly ApplicationDbContext _dbContext;
        private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
        #endregion
        #region Constructors
        public InstructorServies(ApplicationDbContext dbContext,
                                 IInstructorFunctionsRepository instructorFunctionsRepository)
        {
            _dbContext = dbContext;
            _instructorFunctionsRepository = instructorFunctionsRepository;
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
        #endregion
    }
}
