using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {

        [SwaggerOperation(summary: "المستخدمين", OperationId = "Paginated")]
        [HttpGet(Router.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUserPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [SwaggerOperation(summary: "id المستخدم عن طريق ال", OperationId = "GetById")]
        [HttpGet(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetUserByIdQuery(id)));
        }

        [SwaggerOperation(summary: "التسجيل", OperationId = "Create")]
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [SwaggerOperation(summary: "تعديل مستخدم", OperationId = "Edit")]
        [HttpPut(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(summary: "حذف مستخدم", OperationId = "Delete")]
        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteUserCommand(id)));
        }

        [SwaggerOperation(summary: "تغير كلمة السر", OperationId = "ChangePassword")]
        [HttpPut(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(summary: "ارسال كود تغير كلمة السر", OperationId = "SendResetPassword")]
        [HttpPost(Router.ApplicationUserRouting.SendResetPassword)]
        public async Task<IActionResult> SendResetPassword([FromForm] SendResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(summary: "تأكيد الكود", OperationId = "ConfirmResetPassword")]
        [HttpGet(Router.ApplicationUserRouting.ConfirmResetPassword)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
