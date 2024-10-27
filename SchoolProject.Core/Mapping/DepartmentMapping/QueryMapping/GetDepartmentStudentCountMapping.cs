using SchoolProject.Core.Features.Departments.Queries.Response;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountMapping()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentCountResponse>()
                .ForMember(dest => dest.Name, src => src.MapFrom(l => l.GetLocalized(l.DNameAr, l.DNameEn)));
        }

    }
}
