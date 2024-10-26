using SchoolProject.Core.Features.Subjects.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.SubjectMapping

{
    public partial class SubjectProfile
    {
        public void GetSubjectListMapping()
        {
            CreateMap<Subject, GetSubjectListResponse>()
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.SubjectNameAR, src.SubjectNameEn)))
                                .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period));
        }

    }
}

