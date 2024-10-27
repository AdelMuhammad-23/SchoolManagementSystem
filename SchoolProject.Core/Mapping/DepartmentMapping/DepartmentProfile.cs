using AutoMapper;

namespace SchoolProject.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetSDepartmentListMapping();
            GetSingleDepartmentMapping();
            AddDepartmentMapping();
            EditDepartmentMapping();
            GetDepartmentStudentCountMapping();
        }
    }
}
