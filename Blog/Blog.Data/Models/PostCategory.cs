using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class PostCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Key]
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
