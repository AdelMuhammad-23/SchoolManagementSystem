using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstracts.Veiws;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories.Views
{
    public class ViewDepartmentRepository : GenericRepositoryAsync<ViewDepartment>, IViewDepartmentRepository<ViewDepartment>
    {
        #region Fields
        private readonly DbSet<ViewDepartment> _viewDepartments;
        #endregion

        #region Constructors
        public ViewDepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _viewDepartments = dbContext.Set<ViewDepartment>();
        }
        #endregion

        #region Handel Functions

        #endregion
    }
}
