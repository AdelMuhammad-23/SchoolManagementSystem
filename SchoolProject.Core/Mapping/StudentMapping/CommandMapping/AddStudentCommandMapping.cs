using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DID, src => src.MapFrom(dep => dep.DepartmentId))
                           .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameInArbic))
               .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameInEnglish));

        }
    }
}
