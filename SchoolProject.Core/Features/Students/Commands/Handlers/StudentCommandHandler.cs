using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;
using SchoolProject.Servies.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponsesHandler,
                                        IRequestHandler<AddStudentCommand, Responses<string>>
    {
        #region Fields
        private readonly IStudentServies _studentServies;
        private readonly IMapper _mapper;
        #endregion


        #region Constructors
        public StudentCommandHandler(StudentServies studentServies, IMapper mapper)
        {
            _studentServies = studentServies;
            _mapper = mapper;
        }
        #endregion


        #region Handel Functions
        public async Task<Responses<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and student
            var studentmapper = _mapper.Map<Student>(request);
            //add
            var result = await _studentServies.AddStudentAsync(studentmapper);
            //return response
            if (result == "Success") return Created("ADD Successfuly");
            else return BadRequest<string>();
            #endregion

        }
    }
}
