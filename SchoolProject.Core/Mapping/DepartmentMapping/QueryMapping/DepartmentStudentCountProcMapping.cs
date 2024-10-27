using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Response;
using SchoolProject.Data.Entities.Procedures;

namespace SchoolProject.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void DepartmentStudentCountProcMapping()
        {
            CreateMap<GetDepartmentListStudentById, DepartmentStudentCountProcParameter>();
            CreateMap<DepartmentStudentCountProc, GetDepartmentListStudentByIdResponse>()
                                .ForMember(dest => dest.Name, src => src.MapFrom(l => l.GetLocalized(l.DNameAr, l.DNameEn)));

        }
    }
}
