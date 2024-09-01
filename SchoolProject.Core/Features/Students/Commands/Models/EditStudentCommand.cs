using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Responses<string>>
    {
        public int Id { get; set; }
        public string NameInArbic { get; set; }
        public string NameInEnglish { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmementId { get; set; }
    }
}
