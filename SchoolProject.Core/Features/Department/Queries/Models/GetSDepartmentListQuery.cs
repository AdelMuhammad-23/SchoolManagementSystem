using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Response;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
    public class GetSDepartmentListQuery : IRequest<Responses<List<GetSDepartmentListResponse>>>
    {

    }
}
