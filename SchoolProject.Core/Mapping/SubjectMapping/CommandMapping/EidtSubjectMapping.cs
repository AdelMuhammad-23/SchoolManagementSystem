using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.SubjectMapping
{
    public partial class SubjectProfile
    {
        public void EditSubjectMapping()
        {
            CreateMap<EditSubjectCommand, Subject>();
        }
    }
}
