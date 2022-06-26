using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class ShipmentInfo : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string Address { get; set; }

        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")] 
        public string PhoneNumber { get; set; }

        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")] 
        [Required]
        public string MobileNumber { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string City { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string Country { get; set; }
        
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string ZipCode { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string Appartment { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        
        [MaxLength(250)]
        public string Notes { get; set; }
    }
}