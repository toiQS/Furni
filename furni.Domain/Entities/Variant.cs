using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Variant : BaseEntity
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string ColorId { get; set; }
        public Color Color { get; set; }
        public string Thumbnail {  get; set; } = string.Empty;
        public List<string> Images { get; set; } = [];
        public ICollection<VariantSize> VariantSizes { get; set; }
    }
}
