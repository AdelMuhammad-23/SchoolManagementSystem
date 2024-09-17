using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Responses<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
