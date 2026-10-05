using AutoMapper;
using Library_Management_Case_Study.DTO.BookDTO;
using Library_Management_Case_Study.DTO.CategoryDTO;
using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        }
    }
}
