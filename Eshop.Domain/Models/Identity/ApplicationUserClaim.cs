using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models.Identity
{
    [Table("UserClaim", Schema = "dbi")]
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}