using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentQueryHandler : ResponsesHandler,
        IRequestHandler<GetStudentListQuery, Responses<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Responses<GetSingleStudentResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        #region Fields
        private readonly IStudentServies _studentServies;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentServies studentServies, IMapper mapper)
        {
            _studentServies = studentServies;
            _mapper = mapper;
        }

        #endregion

        #region Handle Function
        public async Task<Responses<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentServies.GetStudentsAsync();
            var studentListMapping = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(studentListMapping);
        }

        public async Task<Responses<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentServies.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<GetSingleStudentResponse>("Object Not Found");

            var studentMapping = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(studentMapping);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Department.DName);
            var FilterQuery = _studentServies.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedList;
        }

        #endregion

    }
}
