using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Responses<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
