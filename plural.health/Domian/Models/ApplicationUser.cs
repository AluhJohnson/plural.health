using Microsoft.AspNetCore.Identity;

namespace plural.health.Domian.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
