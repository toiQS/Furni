namespace Furni.MVC.DemoServices.Models
{
    public class BlogModel
    {
        public string BlogId { get; set; } = string.Empty;
        public string BlogName { get; set; } = string.Empty;
        public string UserIdCreated { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
