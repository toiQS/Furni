using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Entities
{
    public class Item
    {
        [Key]
        [Column(name:"Item Id")]
        public string ItemId { get; set; } = string.Empty;
        [ForeignKey(nameof(Product))]
        [Column(name:"Product Id")]
        public string ProductId { get; set; } = string.Empty;
        public virtual Product Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Total {  get; set; }
        [ForeignKey(nameof(Cart))]
        [Column(name:"Cart Id")]
        public string CartId { get; set; } = string.Empty;
        public virtual Cart Cart { get; set; }
    }
}
