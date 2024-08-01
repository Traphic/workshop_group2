using System.ComponentModel.DataAnnotations;

namespace Blog.BlazorServer.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Title must be between 10 and 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(5000, MinimumLength = 50, ErrorMessage = "Content must be between 50 and 5000 characters.")]
        public string Content { get; set; }

        public string? Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public List<CommentViewModel> CommentDTOs { get; set; } = [];

        public List<CategoryViewModel> CategoryDTOs { get; set; } = [];

        public List<int> CategoryIds { get; set; } = [];
    }
}
