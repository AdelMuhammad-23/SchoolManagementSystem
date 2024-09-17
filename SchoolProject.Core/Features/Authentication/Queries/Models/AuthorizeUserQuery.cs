using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Queries.Models
{
    public class AuthorizeUserQuery : IRequest<Responses<string>>
    {
        public string Accesstoken { get; set; }
    }
}
