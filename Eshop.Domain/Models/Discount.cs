using Eshop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class Discount : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        public DiscountType Type { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}