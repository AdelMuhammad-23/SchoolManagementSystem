using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponsesHandler,
        IRequestHandler<AddStudentCommand, Responses<string>>
        , IRequestHandler<EditStudentCommand, Responses<string>>
        , IRequestHandler<DeleteStudentCommand, Responses<string>>

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

        public async Task<Responses<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check student is exist or not
            var checkStudent = await _studentServies.GetByIdAsync(request.ID);
            //if student not found return not found
            if (checkStudent == null) return NotFound<string>(" Student is Not Found");
            //mapping between request and student
            var student = _mapper.Map<Student>(request);
            //call services that make edit
            var result = await _studentServies.EditAsync(student);
            //return response
            return result == "Success" ? Success($"Edit successfully With Id {student.StudID}") :
                                         BadRequest<string>();
        }

        public async Task<Responses<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check student is exist or not
            var student = await _studentServies.GetByIdAsync(request.Id);
            //if student not found return not found
            if (student == null) return NotFound<string>(" Student is Not Found");
            //call services that make delete
            var result = await _studentServies.DeleteAsync(student);

            if (result == "Success")
                return Deleted<string>($"Deleted successfully With Id {student.StudID}");
            else return BadRequest<string>();

        }
        #endregion
    }
}
