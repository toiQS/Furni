using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class ShippingMethod : BaseEntity
    {
        public String Description { get; set; }
        public double Cost { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<DeliveryInformation> DeliveryInformation { get; set; }
    }
}
