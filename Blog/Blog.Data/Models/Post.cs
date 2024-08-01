using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string? Image { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public List<PostCategory> PostCategories { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
