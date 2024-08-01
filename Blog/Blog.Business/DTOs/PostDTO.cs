namespace Blog.Business.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string? Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public List<CommentDTO> CommentDTOs { get; set; } = [];

        public List<CategoryDTO> CategoryDTOs { get; set; } = [];
    }
}
