using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class DepartmentsController : AppControllerBase
    {

        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetStudentListAsync()
        {
            var query = new GetSDepartmentListQuery();
            var result = await Mediator.Send(query);
            return NewResult(result);

        }

        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromQuery] GetDepartmentByIdQuery departmentByIdQuery)
        {
            var result = await Mediator.Send(departmentByIdQuery);
            return NewResult(result);

        }
    }
}
