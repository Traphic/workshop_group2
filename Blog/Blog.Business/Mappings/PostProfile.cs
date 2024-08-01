using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Blog.Business.DTOs;
using Blog.Data.Models;

namespace Blog.Business.Mappings
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.CategoryDTOs, opt => opt.MapFrom(src => src.PostCategories.Select(pc => pc.Category)))
                .ForMember(dest => dest.CommentDTOs, opt => opt.MapFrom(src => src.Comments));

            CreateMap<PostDTO, Post>()
                .ForMember(dest => dest.PostCategories, opt => opt.MapFrom(src => src.CategoryDTOs))
                .ForMember(dest => dest.Comments, opt => opt.Ignore());

            CreateMap<Post, PostListDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.ContentPreview, opt => opt.MapFrom(src => GetContentPreview(src.Content)))
               .ForMember(dest => dest.LastEditedDate, opt => opt.MapFrom(src => src.CreatedDate))
               .ForMember(dest => dest.LastEditedBy, opt => opt.MapFrom(src => src.UpdatedBy ?? src.CreatedBy))
               .ForMember(dest => dest.CategoryDTOs, opt => opt.MapFrom(src => src.PostCategories.Select(pc => pc.Category).ToList()));

            CreateMap<CategoryDTO, PostCategory>()
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
               .EqualityComparison((src, dst) => src.Id == dst.CategoryId);

        }

        private string GetContentPreview(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }
            else
            {
                return content.Length <= 80 ? content : content[..80] + "...";
            }
        }
    }
}
