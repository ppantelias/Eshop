using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Models
{
    public class Origin : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(5)]
        [Column(TypeName = "varchar(5)")]
        public string Abbreviation { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}