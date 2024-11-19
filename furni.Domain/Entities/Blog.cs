using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string BlogName { get; set; } = string.Empty;
        public string Slug { get; set; }
        [ForeignKey("Created_By")]
        public string UserIdCreated { get; set; }
        public virtual User User { get; set; }
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [Column(name: "URL_Image")]
        public string URLImage { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPublic { get; set; } = false;
        public bool IsDeteled { get; set; } = false;
    }
}
