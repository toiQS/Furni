using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Size : BaseEntity
    {
        public string Value { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Variant> ProductVariants { get; set; }
    }
}
