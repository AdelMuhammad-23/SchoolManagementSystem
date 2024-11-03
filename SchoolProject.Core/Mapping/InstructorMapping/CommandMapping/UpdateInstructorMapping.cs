using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.InstructorMapping
{
    public partial class InstructorProfile
    {
        public void UpdateInstructorMapping()
        {
            CreateMap<UpdateInstructorCommand, Instructor>()
                .ForMember(dest => dest.Image, src => src.Ignore());
        }
    }
}
