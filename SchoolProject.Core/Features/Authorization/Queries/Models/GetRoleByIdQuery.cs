using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Response;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Responses<GetRoleByIdResponse>>
    {
        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
