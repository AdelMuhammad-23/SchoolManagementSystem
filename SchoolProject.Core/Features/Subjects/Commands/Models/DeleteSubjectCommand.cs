using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
    public class DeleteSubjectCommand : IRequest<Responses<string>>
    {
        public DeleteSubjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
