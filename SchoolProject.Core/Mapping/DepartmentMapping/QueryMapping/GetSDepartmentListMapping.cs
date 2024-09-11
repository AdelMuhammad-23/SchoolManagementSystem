using SchoolProject.Core.Features.Department.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetSDepartmentListMapping()
        {
            CreateMap<Department, GetSDepartmentListResponse>()
                .ForMember(dis => dis.NameInEnglish, src => src.MapFrom(n => n.DNameEn))
                .ForMember(dis => dis.NameInArabic, src => src.MapFrom(n => n.DNameAr));
        }
    }
}
