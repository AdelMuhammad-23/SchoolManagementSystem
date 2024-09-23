using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.Authorization.CreateRole)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.Authorization.EditRole)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.Authorization.DeleteRole)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteRoleCommand(id)));
        }
    }
}
