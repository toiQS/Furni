using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class Product : BaseEntity
    {
        [Column(name: "Product_Name")]
        public string ProductName { get; set; }

        public float Price { get; set; }

        [Column(name: "URL_Image")]
        public string URLImage { get; set; } = string.Empty;

        [Column(name: "Is_Active")]
        public bool IsActive { get; set; }
    }
}
