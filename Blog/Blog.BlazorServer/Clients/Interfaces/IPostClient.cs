using Blog.BlazorServer.ViewModels;

namespace Blog.BlazorServer.Clients.Interfaces
{
    public interface IPostClient
    {
        Task<HttpResponseMessage> AddAsync(PostViewModel postDTO);

        Task<HttpResponseMessage> UpdateAsync(PostViewModel postDTO);

        Task<HttpResponseMessage> DeleteAsync(int id);

        Task<HttpResponseMessage> GetByIdAsync(int id);

        Task<List<PostListViewModel>> GetAllAsync();

        Task<List<PostListViewModel>> GetAllByCategoryAsync(int categoryId);
    }
}
