using AutoMapper;
using Blog.Business.DTOs;
using Blog.Business.Interfaces;
using Blog.Data.Data;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Business.Services
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext _dbContext;
        private readonly IMapper _mapper;


        public PostService(BlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(PostDTO postDTO)
        {
            if (postDTO is null)
            {
                throw new ArgumentNullException(nameof(postDTO));
            }

            postDTO.CreatedDate = DateTime.Now;
            var newPost = _mapper.Map<Post>(postDTO);
            _dbContext.Posts.Add(newPost);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existingPost = await _dbContext.Posts.FindAsync(id);
            if (existingPost != null)
            {
                _dbContext.Posts.Remove(existingPost);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PostListDTO>> GetAllAsync()
        {
            var posts = await _dbContext.Posts
                .Include(p => p.PostCategories)
                .ThenInclude(pc => pc.Category)
                .ToListAsync();

            return _mapper.Map<List<PostListDTO>>(posts);
        }

        public async Task<PostDTO> GetByIdAsync(int id)
        {
            var post = await _dbContext.Posts
                .Include(p => p.PostCategories)
                .ThenInclude(pc => pc.Category)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return null;
            }

            var postDTO = _mapper.Map<PostDTO>(post);
            return postDTO;
        }

        public async Task UpdateAsync(PostDTO postDTO)
        {
            if (postDTO == null)
            {
                return;
            }

            var dbPost = await _dbContext.Posts
                .Include(p => p.PostCategories)
                .FirstOrDefaultAsync(p => p.Id == postDTO.Id);

            _mapper.Map(postDTO, dbPost);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PostListDTO>> GetByCategoryAsync(int categoryId)
        {
            var posts = await _dbContext.Posts
                .Include(p => p.PostCategories)
                .ThenInclude(pc => pc.Category)
                .Where(p => p.PostCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();

            return _mapper.Map<List<PostListDTO>>(posts); ;
        }
    }
}
