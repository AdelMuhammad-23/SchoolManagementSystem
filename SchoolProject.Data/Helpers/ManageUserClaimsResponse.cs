namespace SchoolProject.Data.Helpers
{
    public class ManageUserClaimsResponse
    {
        public int UserId { get; set; }
        public List<UserClaims> UserClaims { get; set; }
    }
    public class UserClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }


    }
}

