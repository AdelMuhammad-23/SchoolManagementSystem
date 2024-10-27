using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Response;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentListStudentById : IRequest<Responses<GetDepartmentListStudentByIdResponse>>
    {
        public GetDepartmentListStudentById(int dID)
        {
            DID = dID;
        }

        public int DID { get; set; }
    }
}
