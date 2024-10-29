using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Response;

namespace SchoolProject.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorListQuery : IRequest<Responses<List<GetInstructorListResponse>>>
    {
    }
}
