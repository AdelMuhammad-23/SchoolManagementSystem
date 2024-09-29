using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery : IRequest<Responses<ManageUserClaimsResponse>>
    {
        public int Id { get; set; }
        public ManageUserClaimsQuery(int id)
        {
            Id = id;
        }
    }
}
