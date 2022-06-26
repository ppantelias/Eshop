namespace Eshop.Domain.Models
{
    public class OrderStock : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid StockId { get; set; }
        public Stock Stock { get; set; }
        public int Quantity { get; set; }
    }
}