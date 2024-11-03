using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.Commands.Models
{
    public class UpdateInstructorCommand : AddInstructorCommand, IRequest<Responses<string>>
    {
        public int Id { get; set; }
    }
}
