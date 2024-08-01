using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsPositiveReaction { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
