using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class Cart : BaseEntity
    {
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsActive { get; set; }

        public List<CartDetail> CartDetails = [];
    }
}
