using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class DeliveryInformation : BaseEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }

        public string StreetAddress { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public string PaymentMethod { get; set; }

        public string? OrderDescription { get; set; } = string.Empty;

        public string UserId { get; set; }
    }
}
