using System.ComponentModel.DataAnnotations;

namespace furni.Entities
{
    public class Coupon : BaseEntity
    {
        [Required]
        public string CouponCode { get; set; } = string.Empty;

        public string CouponName { get; set; } = string.Empty;

        public int Discount { get; set; }

        public double MinRequire { get; set; }

        public double MaxTotalDiscount { get; set; }

        public DateTime DateExpire { get; set; }

        public DateTime DateStart { get; set; }

        public Order Order { get; set; }
    }
}
