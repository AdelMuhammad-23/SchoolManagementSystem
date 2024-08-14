using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentQueryHandler :ResponsesHandler, 
        IRequestHandler<GetStudentListQuery,Responses<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery,Responses<GetSingleStudentResponse>>

    {
        #region Fields
        private readonly IStudentServies _studentServies;
        private readonly  IMapper _mapper;
        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentServies studentServies , IMapper mapper)
        {
            _studentServies = studentServies;
            _mapper = mapper;
        }

        #endregion

        #region Handle Function
        public async Task< Responses<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentServies.GetStudentsAsync();
            var studentListMapping = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success( studentListMapping);
        }

        public async Task<Responses<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentServies.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<GetSingleStudentResponse>("Object Not Found");

            var studentMapping = _mapper.Map<GetSingleStudentResponse>(student);
            return Success( studentMapping);
        }

        #endregion

    }
}
