using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Responses<string>>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
