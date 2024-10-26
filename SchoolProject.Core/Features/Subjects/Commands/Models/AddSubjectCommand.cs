using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
    public class AddSubjectCommand : IRequest<Responses<string>>
    {
        public string SubjectNameAR { get; set; }
        public string SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
    }
}
