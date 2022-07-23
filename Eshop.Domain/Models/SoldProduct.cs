using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class SoldProduct : BaseEntity
    {
        public Guid ProductId { get; set; }

        [MaxLength(50)]
        public string ProductName { get; set; }

        public Guid OrderId { get; set; }

        [MaxLength(50)]
        public string OrderReference { get; set; }

        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal StartingPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalPrice { get; set; }

        public Guid CouponId { get; set; }
        public Guid DiscountId { get; set; }
        public bool Returned { get; set; }
    }
}