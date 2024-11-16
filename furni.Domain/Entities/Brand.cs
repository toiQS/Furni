using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        public string BrandName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
