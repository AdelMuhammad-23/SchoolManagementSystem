using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<Responses<string>>
    {
        public string RoleName { get; set; }
    }
}
