using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Core.Features.Instructors.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Instructors.Queries.Handlers
{
    internal class InstructorQueryHandler : ResponsesHandler,
                   IRequestHandler<GetSummationSalaryOfInstructorQuery, Responses<decimal>>,
                   IRequestHandler<GetInstructorListQuery, Responses<List<GetInstructorListResponse>>>
    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IInstructorServies _instructorService;
        #endregion
        #region Constructors
        public InstructorQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                      IMapper mapper,
                                      IInstructorServies instructorService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _instructorService = instructorService;
        }

        #endregion
        #region Handle Functions
        public async Task<Responses<decimal>> Handle(GetSummationSalaryOfInstructorQuery request, CancellationToken cancellationToken)
        {
            var result = await _instructorService.GetSalarySummationOfInstructor();
            return Success(result);
        }

        public async Task<Responses<List<GetInstructorListResponse>>> Handle(GetInstructorListQuery request, CancellationToken cancellationToken)
        {
            var instructorList = await _instructorService.GetAllInstructors();
            var instructorListMapping = _mapper.Map<List<GetInstructorListResponse>>(instructorList);
            if (instructorListMapping == null)
                return NotFound<List<GetInstructorListResponse>>("Instructor List  is Empty!");
            return Success(instructorListMapping);
        }
        #endregion
    }
}