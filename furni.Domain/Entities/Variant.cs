using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Variant : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int? ThumbnailId { get; set; }

        [ForeignKey("ThumbnailId")]
        public Image? Thumbnail { get; set; }
        public ICollection<Image> Images { get; set; }
        public int Position { get; set; }
        public ICollection<VariantSize> VariantSizes { get; set; }
    }
}
