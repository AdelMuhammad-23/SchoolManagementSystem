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
    public class StudentCommandHandler :ResponsesHandler,
        IRequestHandler<AddStudentCommand, Responses<string>>
    
    {
        #region Fields
        private readonly IStudentServies _studentServies;
        private readonly IMapper _mapper;
        #endregion


        #region Constructors
        public StudentCommandHandler(IStudentServies studentServies, IMapper mapper)
        {
        
            _studentServies = studentServies;
            _mapper = mapper;
        }
        #endregion


        #region Handel Functions
        public async Task<Responses<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var result = await _studentServies.AddAsync(student);
            return result == "Exist" ? UnprocessableEntity<string>("Name already exists") :
                   result == "Success" ? Created("Added successfully") :
                                         BadRequest<string>();
        }
        #endregion
    }
}
