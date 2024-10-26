using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class SendResetPasswordCommand : IRequest<Responses<string>>
    {
        public string Email { get; set; }
    }
}
