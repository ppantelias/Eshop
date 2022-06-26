using Eshop.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models.Identity
{
    [Table("Role", Schema = "dbi")]
    public class ApplicationRole : IdentityRole<Guid>
    {
        private UserRole _role;

        public ApplicationRole() : base()
        { }

        public ApplicationRole(string role) : base(role)
        { }

        [Required]
        public UserRole UserRole
        {
            get => _role;
            set
            {
                _role = value;
                Name = _role.ToString();
            }
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}