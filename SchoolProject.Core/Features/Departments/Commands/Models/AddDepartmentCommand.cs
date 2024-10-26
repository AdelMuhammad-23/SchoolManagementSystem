using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class AddDepartmentCommand : IRequest<Responses<string>>
    {
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
    }
}
