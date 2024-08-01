using Blog.Business.DTOs;
using Blog.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.WebAPI.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }

        [HttpGet]
        public async Task<ActionResult<List<PostListDTO>>> GetAllPosts()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPostById(int id)
        {
            var post = await _postService.GetByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<PostListDTO>>> GetPostsByCategory(int categoryId)
        {
            var posts = await _postService.GetByCategoryAsync(categoryId);
            return Ok(posts);
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> CreatePost([FromBody] PostDTO post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            
            var user = HttpContext.User;
            var userName = user.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest("User name not found in claims.");
            }

            post.CreatedBy = userName;
            await _postService.CreateAsync(post);

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDTO post)
        {
            if (post == null || id != post.Id)
            {
                return BadRequest();
            }

            var user = HttpContext.User;
            var userName = user.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest("User name not found in claims.");
            }

            post.UpdatedBy = userName;
            await _postService.UpdateAsync(post);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeleteAsync(id);

            return Ok();
        }
    }
}
