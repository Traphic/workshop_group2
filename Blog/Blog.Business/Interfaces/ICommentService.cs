using Blog.Business.DTOs;

namespace Blog.Business.Interfaces
{
    public interface ICommentService
    {
        Task CreateAsync(CommentDTO commentDTO);

        Task DeleteAsync(int id); 

        Task<CommentDTO> GetByIdAsync(int id);

    }
}
