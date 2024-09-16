using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IUserRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
