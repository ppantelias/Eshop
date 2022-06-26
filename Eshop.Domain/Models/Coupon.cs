using Eshop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class Coupon : BaseEntity
    {
        [MaxLength(50)]
        public string Code { get; set; }
        public int MaxRedemptionTimes { get; set; }
        public int RedeemedTimes { get; set; }
        public bool IsRedeemed { get; set; }
        public DateTime? ExpiryDate { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}