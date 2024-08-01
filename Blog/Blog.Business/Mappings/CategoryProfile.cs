using AutoMapper;
using Blog.Business.DTOs;
using Blog.Data.Models;

namespace Blog.Business.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.IsCanBeDeleted, opt => opt.MapFrom(src => !src.PostCategories.Any()));
            CreateMap<CategoryDTO, Category>();
        }
    }
}
