using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Entities
{
    public class Product
    {
        [Key]
        [Column(name:"Product Id")]
        public string ProductId {  get; set; } = string.Empty;
        [Column(name:"Product Name")]
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        [Column(name:"URL Image")]
        public string URLImage { get; set; } = string.Empty ;
        [Column(name:"Is Active")]
        public bool IsActive { get; set; }
        public ICollection<CartDetail> CartDetails { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
