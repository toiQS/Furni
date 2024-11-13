using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class DeliveryInformation : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? CompanyName { get; set; } = string.Empty;

        [Required]
        public string StreetAddress { get; set; }

        public string? AddressDetail { get; set; } = string.Empty;

        [Required]
        public string State { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? OrderNote { get; set; } = string.Empty;

        public string UserId { get; set; }
    }
}
