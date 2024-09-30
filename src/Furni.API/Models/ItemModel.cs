using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Furni.API.Models
{
    public class ItemModel
    {
        public string ItemId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }
        public string CartId { get; set; } = string.Empty;
    }
}
