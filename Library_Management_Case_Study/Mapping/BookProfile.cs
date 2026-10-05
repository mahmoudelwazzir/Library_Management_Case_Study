using AutoMapper;
using Library_Management_Case_Study.DTO.BookDTO;
using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Maping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, CreateBookDTO>().ReverseMap();
            CreateMap<Book, GetBookDTO>().ReverseMap();
        }
    }
}
