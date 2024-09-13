using SchoolProject.Core.Features.ApplicationUser.Queries.Response;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void GetUserPaginatedListQueryMapping()
        {
            CreateMap<User, GetUserPaginatedListResponse>();
        }
    }
}
