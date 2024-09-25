using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class AuthorizationController : AppControllerBase
    {
        [SwaggerOperation(summary: "الصلاحيات", OperationId = "List")]

        [HttpGet(Router.Authorization.List)]
        public async Task<IActionResult> GeRoleList()
        {
            return NewResult(await Mediator.Send(new GetRoleListQuery()));
        }
        [SwaggerOperation(summary: "ادارة صلاحيات المستخدمين", OperationId = "GetManagerUserRole")]
        [HttpGet(Router.Authorization.GetManagerUserRole)]
        public async Task<IActionResult> GetManagerUserRole([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new ManageUserRoleQuery() { UserId = id }));
        }
        [SwaggerOperation(summary: "idالصلاحيه عن طريق ال", OperationId = "GetById")]
        [HttpGet(Router.Authorization.GetById)]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetRoleByIdQuery(id)));
        }
        [SwaggerOperation(summary: "انشاء صلاحية", OperationId = "CreateRole")]
        [HttpPost(Router.Authorization.CreateRole)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [SwaggerOperation(summary: "تعديل صلاحية", OperationId = "EditRole")]
        [HttpPut(Router.Authorization.EditRole)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [SwaggerOperation(summary: "حذف صلاحية", OperationId = "DeleteRole")]
        [HttpDelete(Router.Authorization.DeleteRole)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteRoleCommand(id)));
        }
    }
}
