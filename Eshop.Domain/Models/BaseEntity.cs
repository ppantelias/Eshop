using Eshop.Domain.Enums;
using Eshop.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual EntityState EntityState { get; set; }

        //  Created
        [ForeignKey("UserCreatedById")]
        public virtual ApplicationUser UserCreatedBy { get; set; }
        public virtual Guid UserCreatedById { get; set; }
        public virtual DateTime DateCreated { get; set; }

        //  Updated
        [ForeignKey("UserUpdatedById")] 
        public virtual ApplicationUser UserUpdatedBy { get; set; }
        public virtual Guid? UserUpdatedById { get; set; }
        public virtual DateTime? DateUpdated { get; set; }

        //  Deleted
        [ForeignKey("UserDeletedById")] 
        public virtual ApplicationUser UserDeletedBy { get; set; }
        public virtual Guid? UserDeletedById { get; set; }
        public virtual DateTime? DateDeleted { get; set; }
    }
}