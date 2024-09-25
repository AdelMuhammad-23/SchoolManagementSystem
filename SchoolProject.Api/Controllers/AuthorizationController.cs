using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class AuthorizationController : AppControllerBase
    {
        [HttpGet(Router.Authorization.List)]
        public async Task<IActionResult> GeRoletList()
        {
            return NewResult(await Mediator.Send(new GetRoleListQuery()));
        }
        [HttpGet(Router.Authorization.GetById)]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetRoleByIdQuery(id)));
        }
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
