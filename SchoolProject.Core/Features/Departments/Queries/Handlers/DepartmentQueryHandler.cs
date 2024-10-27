using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Servies.Abstructs;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponsesHandler,
        IRequestHandler<GetDepartmentByIdQuery, Responses<GetSingleDepartmentResponse>>,
        IRequestHandler<GetSDepartmentListQuery, Responses<List<GetSDepartmentListResponse>>>,
        IRequestHandler<GetDepartmentStudentCount, Responses<List<GetDepartmentStudentCountResponse>>>,
        IRequestHandler<GetDepartmentListStudentById, Responses<GetDepartmentListStudentByIdResponse>>


    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IDepartmentServies _departmentServies;
        private readonly IStudentServies _studentServies;
        #endregion

        #region Constructors

        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IMapper mapper,
            IDepartmentServies departmentServies,
            IStudentServies studentServies) : base(stringLocalizer)
        {
            _mapper = mapper;
            _departmentServies = departmentServies;
            _stringLocalizer = stringLocalizer;
            _studentServies = studentServies;
        }
        #endregion

        #region CHandel Functions

        public async Task<Responses<List<GetSDepartmentListResponse>>> Handle(GetSDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentList = await _departmentServies.GetDepartmentAsync();
            var departmentListMapping = _mapper.Map<List<GetSDepartmentListResponse>>(departmentList);
            var result = Success(departmentListMapping);
            result.Meta = new { Count = departmentListMapping.Count() };
            return result;
        }

        public async Task<Responses<GetSingleDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            //call service Get By Id
            var department = await _departmentServies.GetDepartmentByIdAsync(request.Id);
            //Check is exist or not
            if (department == null)
                return NotFound<GetSingleDepartmentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);


            // mapping between from request and response
            var departmentMapping = _mapper.Map<GetSingleDepartmentResponse>(department);

            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.GetLocalized(e.NameAr, e.NameEn));
            var studentQuerable = _studentServies.GetStudentsByDepartmentIdQuerable(request.Id);
            var PaginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            departmentMapping.StudentList = PaginatedList;
            //return response
            return Success(departmentMapping);

        }

        public async Task<Responses<List<GetDepartmentStudentCountResponse>>> Handle(GetDepartmentStudentCount request, CancellationToken cancellationToken)
        {
            var ViewDepartmentStudentCount = await _departmentServies.GetViewDepartmentDataAsync();
            var viewMapping = _mapper.Map<List<GetDepartmentStudentCountResponse>>(ViewDepartmentStudentCount);
            //if (viewMapping == null)
            //    return NotFound<List<GetDepartmentStudentCountResponse>>("");

            return Success(viewMapping);
        }

        public async Task<Responses<GetDepartmentListStudentByIdResponse>> Handle(GetDepartmentListStudentById request, CancellationToken cancellationToken)
        {
            var parameterMapping = _mapper.Map<DepartmentStudentCountProcParameter>(request);
            var procResult = await _departmentServies.GetDepartmentStudentCountProcsDataAsync(parameterMapping);
            var result = _mapper.Map<GetDepartmentListStudentByIdResponse>(procResult.FirstOrDefault());
            return Success(result);
        }

        #endregion

    }
}
