using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Response;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRoleListQuery : IRequest<Responses<List<GetRolesListResponse>>>
    {
    }
}
