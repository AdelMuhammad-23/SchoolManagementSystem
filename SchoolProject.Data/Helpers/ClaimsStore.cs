using System.Security.Claims;

namespace SchoolProject.Data.Helpers
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Create",false.ToString()),
            new Claim("Edit",false.ToString()),
            new Claim("Delete",false.ToString()),
            new Claim("Get",false.ToString()),
        };
    }
}
