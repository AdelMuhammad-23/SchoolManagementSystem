using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class EmailsController : AppControllerBase
    {
        [SwaggerOperation(summary: "ارسال البريد الالكتروني", OperationId = "SendEmail")]
        [HttpPost(Router.EmailRouting.SendEmail)]
        public async Task<IActionResult> SendEmail([FromForm] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
