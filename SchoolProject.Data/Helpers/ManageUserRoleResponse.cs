namespace SchoolProject.Data.Helpers
{
    public class ManageUserRoleResponse
    {
        public int UserId { get; set; }
        public List<UserRoles> Roles { get; set; }
    }
    public class UserRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }


    }
}
