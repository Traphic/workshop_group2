namespace Blog.BlazorServer.ViewModels
{
    public class PostListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Image { get; set; }

        public string ContentPreview { get; set; }

        public DateTime LastEditedDate { get; set; }

        public string LastEditedBy { get; set; }

        public List<CategoryViewModel> CategoryDTOs { get; set; }
    }
}
