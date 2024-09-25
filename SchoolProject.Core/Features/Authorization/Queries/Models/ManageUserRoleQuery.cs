using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserRoleQuery : IRequest<Responses<ManageUserRoleResponse>>
    {
        public int UserId { get; set; }

    }
}
