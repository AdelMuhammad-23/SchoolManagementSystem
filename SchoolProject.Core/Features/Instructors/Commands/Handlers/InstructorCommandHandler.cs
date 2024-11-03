using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Instructors.Commands.Handlers
{
    internal class InstructorCommandHandler : ResponsesHandler,
                   IRequestHandler<DeleteInstructorCommand, Responses<string>>,
                   IRequestHandler<AddInstructorCommand, Responses<string>>
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

        public async Task<Responses<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructorMapping = _mapper.Map<Instructor>(request);
            var result = await _instructorService.AddInstructor(instructorMapping, request.Image);
            switch (result)
            {
                case "this extension is not allowed":
                    return BadRequest<string>("this extension is not allowed");
                case "this image is too big":
                    return BadRequest<string>("this image is too big");
                case "FailedToUploadImage":
                    return BadRequest<string>("FailedToUploadImage");
            }
            return Success("");
        }

        #endregion
    }
}