using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dist => dist.DID, src => src.MapFrom(dep => dep.DepartmentId))
                .ForMember(dist => dist.StudID, src => src.MapFrom(dep => dep.ID));
        }
    }
}
