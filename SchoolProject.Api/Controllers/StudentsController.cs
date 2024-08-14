using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentListAsync()
        {
            var response =await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            var response =await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        } 
        
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            var response =await _mediator.Send(command);
            return Ok(response);
        }
    }
}
