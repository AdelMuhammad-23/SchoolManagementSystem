using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class EditUserClaimsCommand : EditUserClaims, IRequest<Responses<string>>
    {
    }
}
