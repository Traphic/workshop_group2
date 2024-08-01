namespace Blog.Business.DTOs
{
    public class PostListDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Image { get; set; }

        public string ContentPreview { get; set; }

        public DateTime LastEditedDate { get; set; }

        public string LastEditedBy { get; set; }

        public List<CategoryDTO> CategoryDTOs { get; set; }
    }
}

