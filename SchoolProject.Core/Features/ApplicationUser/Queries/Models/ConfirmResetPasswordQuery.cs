using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Models
{
    public class ConfirmResetPasswordQuery : IRequest<Responses<string>>
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
