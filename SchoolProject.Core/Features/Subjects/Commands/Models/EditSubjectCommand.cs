using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
    public class EditSubjectCommand : IRequest<Responses<string>>
    {
        public EditSubjectCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        public string SubjectNameAR { get; set; }
        public string SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
    }
}
