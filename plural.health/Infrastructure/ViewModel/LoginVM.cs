using System.ComponentModel.DataAnnotations;

namespace plural.health.ViewModels
{
    public class LoginVM
    {
        //public int? Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool Remember { get; set; }
    }
}
