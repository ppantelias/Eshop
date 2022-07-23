using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class CartProduct : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal StartingPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalPrice { get; set; }

        public int Quantity { get; set; }
        public Guid StockId { get; set; }
        public Guid? CouponId { get; set; }
        public Guid ProductId { get; set; }

        [MaxLength(50)]
        public string ProductName { get; set; }

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
    }
}