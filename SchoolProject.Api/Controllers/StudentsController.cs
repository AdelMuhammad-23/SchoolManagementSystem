using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Filters;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]

    public class StudentsController : AppControllerBase
    {
        [SwaggerOperation(summary: "الطلاب", OperationId = "List")]
        [HttpGet(Router.StudentRouting.List)]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> GetStudentListAsync()
        {
            return NewResult(await Mediator.Send(new GetStudentListQuery()));
        }

        [AllowAnonymous]
        [SwaggerOperation(summary: "الطلاب", OperationId = "Paginated")]
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [SwaggerOperation(summary: "id الطالب بواسطة ال ", OperationId = "GetById")]
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetStudentByIdQuery(id)));
        }

        [Authorize(policy: "Create")]
        [SwaggerOperation(summary: "اضافة طالب", OperationId = "Create")]
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [Authorize(policy: "Edit")]
        [SwaggerOperation(summary: "تعديل طالب", OperationId = "Edit")]
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [Authorize(policy: "Delete")]
        [SwaggerOperation(summary: "حذف طالب", OperationId = "Delete")]
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
