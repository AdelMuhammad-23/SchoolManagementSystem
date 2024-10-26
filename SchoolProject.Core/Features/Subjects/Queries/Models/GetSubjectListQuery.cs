using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Queries.Response;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectListQuery : IRequest<Responses<List<GetSubjectListResponse>>>
    {
    }
}
