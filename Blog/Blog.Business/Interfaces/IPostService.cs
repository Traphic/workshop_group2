using Blog.Business.DTOs;
using System.Threading.Tasks;

namespace Blog.Business.Interfaces
{
    public interface IPostService
    {
        Task<List<PostListDTO>> GetAllAsync();
        Task<PostDTO> GetByIdAsync(int id);
        Task<List<PostListDTO>> GetByCategoryAsync(int categoryId);
        Task CreateAsync(PostDTO post);
        Task UpdateAsync(PostDTO post);
        Task DeleteAsync(int id);
    }
}
