using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models.Identity
{
    [Table("UserRole", Schema = "dbi")]
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }
    }
}