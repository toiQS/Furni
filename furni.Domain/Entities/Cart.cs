namespace furni.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; }

        public bool IsActive { get; set; }

        public List<CartDetail> CartDetails = [];
    }
}
