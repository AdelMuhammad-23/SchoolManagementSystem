using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class DepartmentsController : AppControllerBase
    {
        [SwaggerOperation(summary: "الأقسام", OperationId = "List")]
        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetStudentListAsync()
        {
            var query = new GetSDepartmentListQuery();
            var result = await Mediator.Send(query);
            return NewResult(result);

        }
        [SwaggerOperation(summary: " الأقسام مع عدد الطلاب", OperationId = "GetListDepartmentStudentCount")]
        [HttpGet(Router.DepartmentRouting.GetListDepartmentStudentCount)]
        public async Task<IActionResult> GetListDepartmentStudentCount()
        {
            var query = new GetDepartmentStudentCount();
            var result = await Mediator.Send(query);
            return NewResult(result);
        }

        [SwaggerOperation(summary: "id القسم عن طريق ال", OperationId = "CreateRole")]
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromQuery] GetDepartmentByIdQuery departmentByIdQuery)
        {
            var result = await Mediator.Send(departmentByIdQuery);
            return NewResult(result);

        }

        [SwaggerOperation(summary: "اضافة قسم", OperationId = "AddDepartment")]
        [HttpPost(Router.DepartmentRouting.AddDepartment)]
        public async Task<IActionResult> AddDepartment([FromForm] AddDepartmentCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);

        }

        [SwaggerOperation(summary: "تعديل قسم", OperationId = "EditDepartment")]
        [HttpPut(Router.DepartmentRouting.EditDepartment)]
        public async Task<IActionResult> EditDepartment([FromForm] EditDepartmentCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);

        }

        [SwaggerOperation(summary: "حذف قسم", OperationId = "DeleteDepartment")]
        [HttpDelete(Router.DepartmentRouting.DeleteDepartment)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteDepartmentCommand(id));
            return NewResult(result);

        }
    }
}
