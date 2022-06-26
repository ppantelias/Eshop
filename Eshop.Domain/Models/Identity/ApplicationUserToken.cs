using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models.Identity
{
    [Table("UserToken", Schema = "dbi")]
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}