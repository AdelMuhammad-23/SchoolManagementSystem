using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Core.Features.Subjects.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Subjects.Queries.Handlers
{
    public class SubjectQueryHandler : ResponsesHandler,
        IRequestHandler<GetSubjectListQuery, Responses<List<GetSubjectListResponse>>>,
        IRequestHandler<GetSubjectByIdQuery, Responses<GetSubjectByIdResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly ISubjectServies _subjectServies;
        #endregion

        #region Constructors
        public SubjectQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, ISubjectServies subjectServies) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _subjectServies = subjectServies;
        }
        #endregion

        #region Handle Functions
        public async Task<Responses<List<GetSubjectListResponse>>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            var subjectList = await _subjectServies.GetSubjectsAsync();
            if (subjectList == null)
                return NotFound<List<GetSubjectListResponse>>("");
            var SubjectListMapping = _mapper.Map<List<GetSubjectListResponse>>(subjectList);
            return Success(SubjectListMapping);
        }

        public async Task<Responses<GetSubjectByIdResponse>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            var subject = await _subjectServies.GetSubjectsByIdAsync(request.Id);
            if (subject == null)
                return NotFound<GetSubjectByIdResponse>("");
            var subjectMapping = _mapper.Map<GetSubjectByIdResponse>(subject);
            return Success(subjectMapping);
        }
        #endregion
    }
}
