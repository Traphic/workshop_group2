namespace Blog.Business.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsPositiveReaction { get; set; } 

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public int PostId { get; set; }
    }
}
