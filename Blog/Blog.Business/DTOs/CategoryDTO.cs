namespace Blog.Business.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCanBeDeleted { get; set; }
    }
}
