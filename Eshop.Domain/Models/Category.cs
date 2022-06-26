using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class Category : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public Guid ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Category Parent { get; set; }
        public Guid RootId { get; set; }

        [ForeignKey("RootId")]
        public Category Root { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
    }
}