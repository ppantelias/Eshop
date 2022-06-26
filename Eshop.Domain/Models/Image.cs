using System.ComponentModel.DataAnnotations;

namespace Eshop.Domain.Models
{
    public class Image : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        
        [MaxLength(500)]
        public string Url { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}