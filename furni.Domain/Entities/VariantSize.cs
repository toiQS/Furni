using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class VariantSize : BaseEntity
    {
        public int VariantId { get; set; }
        public Variant Variant { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public ICollection<OrderDetail> Details { get; set; }
    }
}
