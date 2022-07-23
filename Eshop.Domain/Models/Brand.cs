using System.ComponentModel.DataAnnotations;

namespace Eshop.Domain.Models
{
    public class Brand : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
        public Guid OriginId { get; set; }
        public Origin Origin { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
    }
}