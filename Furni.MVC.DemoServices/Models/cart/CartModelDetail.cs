using Furni.MVC.DemoServices.Models.item;

namespace Furni.MVC.DemoServices.Models.cart
{
    public class CartModelDetail
    {
        public string CartId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public List<ItemModelResponse> Items { get; set; }
    }
}
