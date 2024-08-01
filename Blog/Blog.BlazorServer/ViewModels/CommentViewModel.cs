using System.ComponentModel.DataAnnotations;

namespace Blog.BlazorServer.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment text is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Comment text must be between 5 and 100 characters.")]
        public string Text { get; set; }

        public bool IsPositiveReaction { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public int PostId { get; set; }
    }
}
