using System.ComponentModel.DataAnnotations;

namespace Eshop.Domain.Models
{
    public class StockOnHold : BaseEntity
    {
        [MaxLength(100)]
        public string SessionId { get; set; }
        public Stock Stock { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}