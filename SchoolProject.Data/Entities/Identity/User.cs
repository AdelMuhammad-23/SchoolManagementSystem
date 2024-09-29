using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        [Key]
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        [InverseProperty(nameof(UserRefreshToken.user))]
        public virtual ICollection<UserRefreshToken> userRefreshToken { get; set; }
    }
}
