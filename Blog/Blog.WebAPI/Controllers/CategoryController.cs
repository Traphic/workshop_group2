using Microsoft.AspNetCore.Mvc;
using Blog.Business.DTOs;
using Blog.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Blog.WebAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(); 
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest(); 
            }

            await _categoryService.CreateAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            if (id != category?.Id)
            {
                return BadRequest(); 
            }

            try
            {
                await _categoryService.UpdateAsync(category);
            }
            catch (Exception)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(); 
            }

            await _categoryService.DeleteAsync(id);
            return NoContent(); 
        }

        [HttpGet("assigned")]
        [AllowAnonymous]
        public async Task<ActionResult<List<CategoryDTO>>> GetAssignedCategories()
        {
            var unassignedCategories = await _categoryService.GetAssignedCategoriesAsync();
            return Ok(unassignedCategories);
        }
    }
}
