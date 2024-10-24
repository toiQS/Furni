using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Entities
{
    public class Blog
    {
        [Key]
        [Column(name:"Blog Id")]
        public string BlogId { get; set; } = string.Empty;
        [Column(name:"Blog Name")]
        public string BlogName { get; set; } = string.Empty ;
        //[Column(name: "User Id Created")]
        [ForeignKey("CreatedByUser")]
        public string UserIdCreated { get; set; }
        public virtual User CreatedByUser { get; set; }
        [Column(name:"Create At")]
        public DateTime CreateAt { get; set; }
        [Column(name:"Update At")]
        public DateTime UpdateAt { get; set; }
        [Column(name: "URL Image")]
        public string URLImage { get; set; } = string.Empty;
    }
}
