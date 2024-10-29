using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.Commands.Models
{
    public class DeleteInstructorCommand : IRequest<Responses<string>>
    {
        public DeleteInstructorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
