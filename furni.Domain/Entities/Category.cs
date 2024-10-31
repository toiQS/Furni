using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public IList<Product> Products { get; set; }
    }
}
