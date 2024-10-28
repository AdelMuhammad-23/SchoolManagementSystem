using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastructure.Abstracts.Functions;
using SchoolProject.Infrastructure.Data;
using System.Data;

namespace SchoolProject.Infrastructure.Repositories.Functions
{
    public class InstructorFunctionsRepository : IInstructorFunctionsRepository
    {
        #region Fileds
        private readonly ApplicationDbContext _dbContext;
        #endregion
        #region Constructors
        public InstructorFunctionsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion
        #region Handle Functions
        public decimal GetSalarySummationOfInstructor(string query)
        {
            using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                decimal response = 0;
                cmd.CommandText = query;
                var value = cmd.ExecuteScalar();
                var result = value.ToString();
                if (decimal.TryParse(result, out decimal d))
                {
                    response = d;
                }
                cmd.Connection.Close();
                return response;
            }
        }
        #endregion
    }
}
