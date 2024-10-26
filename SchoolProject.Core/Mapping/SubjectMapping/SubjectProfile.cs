using AutoMapper;

namespace SchoolProject.Core.Mapping.SubjectMapping
{
    public partial class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            GetSubjectListMapping();
            AddSubjectMapping();
            GetSubjectByIdMapping();
            EditSubjectMapping();
        }
    }
}
