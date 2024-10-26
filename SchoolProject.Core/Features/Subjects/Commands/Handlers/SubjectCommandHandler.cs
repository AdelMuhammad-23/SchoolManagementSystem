using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Subjects.Commands.Handlers
{
    public class SubjectCommandHandler : ResponsesHandler,
        IRequestHandler<AddSubjectCommand, Responses<string>>,
        IRequestHandler<EditSubjectCommand, Responses<string>>,
        IRequestHandler<DeleteSubjectCommand, Responses<string>>
    {
        #region Fields
        private readonly ISubjectServies _subjectServies;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public SubjectCommandHandler(ISubjectServies subjectServies, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper) : base(stringLocalizer)
        {
            _subjectServies = subjectServies;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }

        #endregion

        #region Handle Functions
        public async Task<Responses<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var SubjectMapping = _mapper.Map<Subject>(request);
            var subject = await _subjectServies.AddSubjectsAsync(SubjectMapping);
            return subject == "Success" ? Created("") :
                                        BadRequest<string>();
        }

        public async Task<Responses<string>> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _subjectServies.GetSubjectsByIdAsync(request.Id);
            if (subject == null)
                return NotFound<string>("");
            var subjectMapping = _mapper.Map(request, subject);
            var updatSubject = await _subjectServies.EditSubjectsAsync(subjectMapping);
            if (updatSubject == "Success")
                return Success<string>("Edit Successfully");
            return BadRequest<string>();
        }

        public async Task<Responses<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _subjectServies.GetSubjectsByIdAsync(request.Id);
            if (subject == null)
                return NotFound<string>("");
            var subjectDeleted = await _subjectServies.DeleteSubjectsAsync(subject);
            if (subjectDeleted == "Success")
                return Success<string>("Deleted Successfully");
            return BadRequest<string>();
        }
        #endregion
    }
}
