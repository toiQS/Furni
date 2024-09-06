namespace Furni.API.Models
{
    public class CartModel
    {
        public string CartId { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
