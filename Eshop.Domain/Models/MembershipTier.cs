using Eshop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class MembershipTier : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal LoyaltyWeight { get; set; }

        public int LowerLimitPoints { get; set; }
        public int HigherLimitPoints { get; set; }
        public MembershipType Type { get; set; }
        public ICollection<LoyaltyMembership> LoyaltyMemberships { get; set; }
    }
}