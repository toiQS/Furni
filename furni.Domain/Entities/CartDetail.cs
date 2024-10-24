using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Entities
{
    public class CartDetail
    {
        [Key]
        public string OrderDetailId { get; set; }
        public string ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
        public float Total { get; set; }
        public string CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
