using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponsesHandler,
        IRequestHandler<AddStudentCommand, Responses<string>>,
        IRequestHandler<EditStudentCommand, Responses<string>>,
        IRequestHandler<DeleteStudentCommand, Responses<string>>


    {
        #region Fields
        private readonly IStudentServies _studentServies;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors
        public StudentCommandHandler(IStudentServies studentServies,
                                    IMapper mapper,
                                    IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {

            _studentServies = studentServies;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion


        #region Handel Functions
        public async Task<Responses<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var result = await _studentServies.AddAsync(student);
            return result == "Success" ? Created("") :
                                         BadRequest<string>();
        }


        public async Task<Responses<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var student = await _studentServies.GetByIDAsync(request.Id);
            //return NotFound
            if (student == null)
                return NotFound<string>("student Not Found");
            //mapping Between request and student
            var studentmapper = _mapper.Map(request, student);
            //Call service that make Edit
            var result = await _studentServies.EditAsync(studentmapper);
            //return response
            if (result == "Success") return Success<string>("SSS");
            else return BadRequest<string>();
        }
        public async Task<Responses<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var student = await _studentServies.GetByIDAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _studentServies.DeleteAsync(student);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
        #endregion

    }
}

