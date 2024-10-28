using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
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
    }
}
