using AutoMapper;

namespace SchoolProject.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetRoleListQueryMapping();
            GetRoleByIdQueryMapping();
        }
    }
}
