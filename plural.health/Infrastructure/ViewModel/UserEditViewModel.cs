using System.ComponentModel.DataAnnotations;

namespace plural.health.ViewModels
{
    public class UserEditViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Institution { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public string? Password { get; set; }
    }
}
