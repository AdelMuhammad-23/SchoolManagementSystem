using AutoMapper;

namespace SchoolProject.Core.Mapping.InstructorMapping
{
    public partial class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            GetInstructorListMapping();
            AddInstructorMapping();
        }
    }
}
