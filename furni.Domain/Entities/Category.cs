using System.ComponentModel.DataAnnotations;

namespace furni.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public string CategoryDescription { get; set; } = string.Empty;

        public IList<Product> Products { get; set; }
    }
}
