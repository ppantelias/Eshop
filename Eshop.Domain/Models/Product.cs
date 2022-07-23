using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class Product : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Coupon> Coupons { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal InitialValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentValue { get; set; }

        public bool IsNewArrival { get; set; }
        public bool IsVisible { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}