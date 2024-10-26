using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Queries.Response;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectByIdQuery : IRequest<Responses<GetSubjectByIdResponse>>
    {
        public GetSubjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
