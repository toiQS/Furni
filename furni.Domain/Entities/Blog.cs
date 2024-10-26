using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Entities
{
    public class Blog : BaseEntity
    {
        [Column(name: "Blog_Name")]
        public string BlogName { get; set; } = string.Empty;

        [ForeignKey("Created_By")]
        public string UserIdCreated { get; set; }

        public virtual User CreatedByUser { get; set; }

        [Column(name: "Create_At")]
        public DateTime CreateAt { get; set; }

        [Column(name: "Update_At")]
        public DateTime UpdateAt { get; set; }

        [Column(name: "URL_Image")]
        public string URLImage { get; set; } = string.Empty;
    }
}
