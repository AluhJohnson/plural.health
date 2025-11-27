using System.ComponentModel.DataAnnotations;

namespace plural.health.Models
{

    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Institution { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
     
        public string? UserName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string? RoleId { get; set; }

    }

    public class UserDTO
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Institution { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public string? UserName { get; set; }
        public string Email { get; set; }

        //public List<UserRoleRequest>? UserRoleRequests { get; set; }
    }




}
