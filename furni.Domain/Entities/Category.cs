using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace furni.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
