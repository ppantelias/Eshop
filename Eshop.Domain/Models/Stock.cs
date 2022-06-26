namespace Eshop.Domain.Models
{
    public class Stock : BaseEntity
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<OrderStock> OrderStocks { get; set; }
    }
}