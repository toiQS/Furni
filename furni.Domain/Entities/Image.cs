using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string? Name { get; set; }
        public int? VariantId { get; set; }
    }
}
