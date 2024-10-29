using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Instructors.Commands.Handlers
{
    internal class InstructorCommandHandler : ResponsesHandler,
                   IRequestHandler<DeleteInstructorCommand, Responses<string>>
    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IInstructorServies _instructorService;
        #endregion
        #region Constructors
        public InstructorCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                      IMapper mapper,
                                      IInstructorServies instructorService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _instructorService = instructorService;
        }


        #endregion
        #region Handle Functions
        public async Task<Responses<string>> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorService.GetInstructorById(request.Id);
            if (instructor == null)
                return NotFound<string>("Not found Instructor with this id!");
            var deleteInstructor = await _instructorService.DeleteInstructor(instructor);
            return Deleted<string>();

        }

        #endregion
    }
}