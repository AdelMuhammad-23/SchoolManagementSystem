using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentsController : AppControllerBase
    {
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentListAsync()
        {
            return NewResult(await Mediator.Send(new GetStudentListQuery()));
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetStudentByIdQuery(id)));
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }


        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> Update([FromBody] EditStudentCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
