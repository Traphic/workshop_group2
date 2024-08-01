using AutoMapper;
using Blog.Business.DTOs;
using Blog.Data.Models;

namespace Blog.Business.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
        }
    }
}
