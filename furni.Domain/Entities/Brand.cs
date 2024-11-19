using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Product> Products { get; set; }
    }
}
