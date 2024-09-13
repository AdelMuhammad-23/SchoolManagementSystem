using AutoMapper;

namespace SchoolProject.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserCommandMapping();
        }
    }
}
