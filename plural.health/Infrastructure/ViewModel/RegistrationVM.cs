using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace plural.health.ViewModels
{
    public class RegistrationVM
    {
        //public int Id{ get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
     
        public string? UserName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

    }

    public class ManagementRegistrationVM : RegistrationVM
    {
        public string? RoleId { get; set; }
        public List<IdentityRole>? Role { get; set; }
    }
}
