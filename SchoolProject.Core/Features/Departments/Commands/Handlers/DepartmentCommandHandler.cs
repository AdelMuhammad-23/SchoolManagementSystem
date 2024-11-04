using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : ResponsesHandler,
        IRequestHandler<AddDepartmentCommand, Responses<string>>,
        IRequestHandler<DeleteDepartmentCommand, Responses<string>>,
        IRequestHandler<EditDepartmentCommand, Responses<string>>
    {
        #region Fields
        private readonly IDepartmentServies _departmentServies;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DepartmentCommandHandler(IDepartmentServies departmentServies,
                                        IStringLocalizer<SharedResources> stringLocalizer,
                                        IMapper mapper) : base(stringLocalizer)
        {
            _departmentServies = departmentServies;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }

        #endregion

        #region Handel Functions
        public async Task<Responses<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);
            var result = await _departmentServies.AddDepartmentAsync(department);
            return result == "Success" ? Created("") :
                                         BadRequest<string>();
        }

        public async Task<Responses<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var department = await _departmentServies.GetDepartmentByIdAsync(request.Id);
            //return NotFound
            //if (department == null)
            //{
            //    Log.Error("This Department is not found");
            //    return NotFound<string>();
            //}
            //Call service that make Delete
            var result = await _departmentServies.DeleteDepartmentAsync(department);
            if (result == "Success") return Deleted<string>("Deleted is Done");
            else if (result == "Failed") return BadRequest<string>();
            return BadRequest<string>();

        }

        public async Task<Responses<string>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var department = await _departmentServies.GetDepartmentByIdAsync(request.id);
            //return NotFound
            if (department == null) return NotFound<string>();
            var departmentMapping = _mapper.Map(request, department);
            var updateDepartment = await _departmentServies.updateDepartmentAsync(departmentMapping);
            if (updateDepartment == "Success") return Success<string>("Edit Successfully");
            else return BadRequest<string>();

        }
        #endregion
    }
}
