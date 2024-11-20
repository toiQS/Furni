using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; }
        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string Image { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPublic { get; set; } = false;
        public bool IsDeteled { get; set; } = false;
    }
}
