using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class Blog : BaseEntity
    {
        [Column(name: "Blog_Name")]
        public string BlogName { get; set; } = string.Empty;

        [ForeignKey("Created_By")]
        public string UserIdCreated { get; set; }

        public virtual User User { get; set; }

        [Column(name: "Create_At")]
        public DateTime CreateAt { get; set; }

        [Column(name: "Update_At")]
        public DateTime UpdateAt { get; set; }

        [Column(name: "URL_Image")]
        public string URLImage { get; set; } = string.Empty;
    }
}
