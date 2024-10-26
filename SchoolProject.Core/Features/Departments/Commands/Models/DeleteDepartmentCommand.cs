using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommand : IRequest<Responses<string>>
    {
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
