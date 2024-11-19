using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Size : BaseEntity
    {
        public int Value { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
