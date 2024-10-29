using SchoolProject.Core.Features.Instructors.Queries.Response;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.InstructorMapping
{
    public partial class InstructorProfile
    {
        public void GetInstructorListMapping()
        {
            CreateMap<Instructor, GetInstructorListResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAR, src.NameEr)));
        }
    }
}
