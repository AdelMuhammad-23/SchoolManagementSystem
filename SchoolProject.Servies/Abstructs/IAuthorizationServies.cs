namespace SchoolProject.Servies.Abstructs
{
    public interface IAuthorizationServies
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExist(string roleName);
    }
}
