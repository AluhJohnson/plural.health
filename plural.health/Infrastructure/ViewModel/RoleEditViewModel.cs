using Microsoft.AspNetCore.Identity;
using plural.health.Domian.Models;
using System.ComponentModel.DataAnnotations;

namespace plural.health.ViewModels
{
    public class RoleEditViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }

    public class RoleModificationViewModel
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[]? AddIds { get; set; }

        public string[]? DeleteIds { get; set; }
    }

    public class ApproveRoleViewModel
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }
}
