using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void EditDepartmentMapping()
        {
            CreateMap<EditDepartmentCommand, Department>();
        }
    }
}
