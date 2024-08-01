using AutoMapper;
using Blog.Business.DTOs;
using Blog.Business.Interfaces;
using Blog.Data.Data;
using Blog.Data.Models;

namespace Blog.Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(BlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CommentDTO commentDTO)
        {
            if (commentDTO is null)
            {
                throw new ArgumentNullException(nameof(commentDTO));
            }

            var newComment = _mapper.Map<Comment>(commentDTO);
            newComment.CreatedDate = DateTime.Now;
            _dbContext.Comments.Add(newComment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<CommentDTO> GetByIdAsync(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }

            var commentDTO = _mapper.Map<CommentDTO>(comment);
            return commentDTO;
        }
    }
}
