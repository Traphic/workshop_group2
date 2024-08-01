using Blog.BlazorServer.ViewModels;

namespace Blog.BlazorServer.Clients.Interfaces
{
    public interface ICategoryClient
    {
        Task<HttpResponseMessage> AddAsync(CategoryViewModel categoryDTO);

        Task<HttpResponseMessage> UpdateAsync(CategoryViewModel categoryDTO);

        Task<HttpResponseMessage> DeleteAsync(int id);

        Task<List<CategoryViewModel>> GetAllAsync();

        Task<List<CategoryViewModel>> GetAssignedCategoriesAsync();
    }
}
