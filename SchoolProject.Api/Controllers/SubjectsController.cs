using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class SubjectsController : AppControllerBase
    {
        [SwaggerOperation(summary: "المواد العلميه", OperationId = "GetSubjectList")]
        [HttpGet(Router.SubjectRouting.GetSubjectList)]
        public async Task<IActionResult> GetSubjectList()
        {
            return NewResult(await Mediator.Send(new GetSubjectListQuery()));
        }

        [SwaggerOperation(summary: "اضافة ماده علمية", OperationId = "AddSubject")]
        [HttpPost(Router.SubjectRouting.AddSubject)]
        public async Task<IActionResult> AddSubject([FromBody] AddSubjectCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [SwaggerOperation(summary: "id الماده بواسطة ال", OperationId = "GetSubjectById")]
        [HttpGet(Router.SubjectRouting.GetSubjectById)]
        public async Task<IActionResult> GetSubjectById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetSubjectByIdQuery(id)));
        }

        [SwaggerOperation(summary: "تعديل ماده", OperationId = "EditSubject")]
        [HttpPut(Router.SubjectRouting.EditSubject)]
        public async Task<IActionResult> EditSubject([FromBody] EditSubjectCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [SwaggerOperation(summary: "حذف ماده ", OperationId = "DeleteSubject")]
        [HttpDelete(Router.SubjectRouting.DeleteSubject)]
        public async Task<IActionResult> DeleteSubject([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteSubjectCommand(id)));
        }
    }
}
