using Eshop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Domain.Models
{
    public class Order : BaseEntity
    {
        [MaxLength(50)]
        public string OrderReference { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid ShipmentInfoId { get; set; }
        public ShipmentInfo ShipmentInfo { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public Cart Cart { get; set; }
        public ICollection<OrderStock> OrderStocks { get; set; }
    }
}