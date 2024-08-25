using MediatR;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Core.Wrapper;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedResponse>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public StudentOrderingEnum orderBy { get; set; }
        public string? search { get; set; }

    }
}
