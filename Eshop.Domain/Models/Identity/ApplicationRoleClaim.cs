using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models.Identity
{
    [Table("RoleClaim", Schema = "dbi")]
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }
    }
}