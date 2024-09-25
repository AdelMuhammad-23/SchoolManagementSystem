using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile
    {
        public void GetRoleListQueryMapping()
        {
            CreateMap<Role, GetRolesListResponse>();
        }

    }
}
