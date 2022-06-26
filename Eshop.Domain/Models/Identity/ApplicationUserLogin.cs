using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models.Identity
{
    [Table("UserLogin", Schema = "dbi")]
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}