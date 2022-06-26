namespace Eshop.Domain.Models
{
    public class Card : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string EncryptedInfo { get; set; }
    }
}