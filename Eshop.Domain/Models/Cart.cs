using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class Cart : BaseEntity
    {
        [MaxLength(50)]
        public string CartReference { get; set; }

        [MaxLength(100)]
        public string SessionId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public int LoyaltyPointsUsed { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
    }
}