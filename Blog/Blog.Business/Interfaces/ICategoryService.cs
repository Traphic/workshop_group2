using Blog.Business.DTOs;

namespace Blog.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllAsync();

        Task<CategoryDTO> GetByIdAsync(int id);

        Task CreateAsync(CategoryDTO category);

        Task UpdateAsync(CategoryDTO category);

        Task DeleteAsync(int id);

        Task<List<CategoryDTO>> GetAssignedCategoriesAsync();
    }
}
