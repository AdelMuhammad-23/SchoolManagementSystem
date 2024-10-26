using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class EditDepartmentCommand : IRequest<Responses<string>>
    {

        public int id { get; set; }
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }

    }
}
