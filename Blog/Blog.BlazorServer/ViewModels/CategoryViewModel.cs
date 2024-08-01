using System.ComponentModel.DataAnnotations;

namespace Blog.BlazorServer.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 15 characters.")]
        public string Name { get; set; }

        public bool IsCanBeDeleted { get; set; }
    }
}
