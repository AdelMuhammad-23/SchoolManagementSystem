using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ConfirmEmailCommand : IRequest<Responses<string>>
    {
        public int userId { get; set; }
        public string Code { get; set; }
    }
}
