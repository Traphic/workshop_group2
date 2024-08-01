using AutoMapper;
using Blog.Business.DTOs;
using Blog.Business.Interfaces;
using Blog.Data.Data;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(BlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
            {
                throw new ArgumentNullException(nameof(categoryDTO));
            }

            var newCategory = _mapper.Map<Category>(categoryDTO);
            _dbContext.Categories.Add(newCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var categories = await _dbContext.Categories
                .Include(c => c.PostCategories)
                .ToListAsync();

            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return;
            }

            var category = await _dbContext.Categories.FindAsync(categoryDTO.Id);

            _mapper.Map(categoryDTO, category);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryDTO>> GetAssignedCategoriesAsync()
        {
            return await GetAllAsync();
        }
    }
}
