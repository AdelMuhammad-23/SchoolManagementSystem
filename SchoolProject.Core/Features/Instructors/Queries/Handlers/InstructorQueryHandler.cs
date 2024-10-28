using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Instructors.Queries.Handlers
{
    internal class InstructorQueryHandler : ResponsesHandler,
                   IRequestHandler<GetSummationSalaryOfInstructorQuery, Responses<decimal>>
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
        #endregion
    }
}