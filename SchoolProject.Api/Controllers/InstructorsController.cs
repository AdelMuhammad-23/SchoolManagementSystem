using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : AppControllerBase
    {
        [SwaggerOperation(summary: "المجموع الكلي لمرتبات المدرسين", OperationId = "GetSalarySummationOfInstructor")]
        [HttpGet(Router.InstructorRouting.GetSalarySummationOfInstructor)]
        public async Task<IActionResult> GetSalarySummation()
        {
            return NewResult(await Mediator.Send(new GetSummationSalaryOfInstructorQuery()));
        }
        [SwaggerOperation(summary: "قائمة المدرسين", OperationId = "GetInstructorListQuery")]
        [HttpGet(Router.InstructorRouting.GetInstructorList)]
        public async Task<IActionResult> GetInstructorList()
        {
            return NewResult(await Mediator.Send(new GetInstructorListQuery()));
        }
        [SwaggerOperation(summary: "حذف مدرس", OperationId = "DeleteInstructor")]
        [HttpDelete(Router.InstructorRouting.DeleteInstructor)]
        public async Task<IActionResult> DeleteInstructor([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteInstructorCommand(id)));
        }
        [SwaggerOperation(summary: "اضافة مدرس", OperationId = "AddInstructor")]
        [HttpPost(Router.InstructorRouting.AddInstructor)]
        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
        {

            return NewResult(await Mediator.Send(command));
        }
    }
}
