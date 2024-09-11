using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Response;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Responses<GetSingleDepartmentResponse>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
