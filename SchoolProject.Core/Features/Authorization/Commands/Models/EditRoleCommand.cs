using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : IRequest<Responses<string>>
    {
        public int Id { get; set; }
        public string oldRole { get; set; }
        public string newRole { get; set; }
    }
}
