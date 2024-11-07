using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        public string BrandName { get; set; }

        public string BrandDescription { get; set; } = string.Empty;

        [EmailAddress]
        public string BrandEmail { get; set; } = string.Empty;

        [Phone]
        public string BrandPhone { get; set; } = string.Empty;
        //public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
