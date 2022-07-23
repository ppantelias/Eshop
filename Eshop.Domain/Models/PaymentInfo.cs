using Eshop.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class PaymentInfo : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public PaymentType Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CashOnDeliveryCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValueBeforeTaxes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetValue { get; set; }
    }
}