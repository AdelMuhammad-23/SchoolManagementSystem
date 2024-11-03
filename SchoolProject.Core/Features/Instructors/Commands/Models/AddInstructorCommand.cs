using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.Commands.Models
{
    public class AddInstructorCommand : IRequest<Responses<string>>
    {
        public string? NameAR { get; set; }
        public string? NameEr { get; set; }
        public string? Address { get; set; }
        public IFormFile? Image { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }
    }
}
