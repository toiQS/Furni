using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class ShippingMethod : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Cost { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Order> Orders { get; set; }
    }
}
