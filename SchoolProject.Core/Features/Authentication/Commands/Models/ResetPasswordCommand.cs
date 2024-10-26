using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Responses<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }

    }
}
