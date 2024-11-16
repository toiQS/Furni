using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public IList<Product> Products { get; set; }
    }
}
