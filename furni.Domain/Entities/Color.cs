using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
