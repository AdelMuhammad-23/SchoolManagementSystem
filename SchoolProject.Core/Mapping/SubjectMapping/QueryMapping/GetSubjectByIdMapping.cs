using SchoolProject.Core.Features.Subjects.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.SubjectMapping
{
    public partial class SubjectProfile
    {
        public void GetSubjectByIdMapping()
        {
            CreateMap<Subject, GetSubjectByIdResponse>()
                .ForMember(dest => dest.Name, src => src.MapFrom(l => l.GetLocalized(l.SubjectNameAR, l.SubjectNameEn)));
        }
    }
}
