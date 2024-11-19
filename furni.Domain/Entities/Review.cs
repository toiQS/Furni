using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
