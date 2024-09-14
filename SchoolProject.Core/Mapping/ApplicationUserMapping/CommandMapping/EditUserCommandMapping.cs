using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void EditUserCommandMapping()
        {
            CreateMap<EditUserCommand, User>();
        }
    }
}
