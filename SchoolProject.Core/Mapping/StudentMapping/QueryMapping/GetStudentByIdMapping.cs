using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {

        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
                .ForMember(dest => dest.DepartmentName, src => src.MapFrom(dep => dep.GetLocalized(dep.Department.DNameAr, dep.Department.DNameEn)))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)));

        }
    }
}
