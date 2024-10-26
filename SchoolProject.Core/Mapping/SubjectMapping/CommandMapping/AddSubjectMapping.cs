using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.SubjectMapping

{
    public partial class SubjectProfile
    {
        public void AddSubjectMapping()
        {
            CreateMap<AddSubjectCommand, Subject>()
                                .ForMember(dest => dest.SubjectNameAR, opt => opt.MapFrom(src => src.SubjectNameAR))
               .ForMember(dest => dest.SubjectNameEn, opt => opt.MapFrom(src => src.SubjectNameEn))
               .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period));

        }
    }

}


