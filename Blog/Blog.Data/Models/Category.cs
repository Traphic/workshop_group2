using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<PostCategory> PostCategories { get; set; }
    }
}
