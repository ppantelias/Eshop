using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class Customer : BaseEntity
    {
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string MobileNumber { get; set; }

        public bool IsMember { get; set; }
        public ICollection<ShipmentInfo> ShipmentInfos { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<LoyaltyMembership> LoyaltyMemberships { get; set; }
    }
}