using AutoMapper;
using Library_Management_Case_Study.DTO.BookDTO;
using Library_Management_Case_Study.DTO.MemberDTO;
using Library_Management_Case_Study.Models;
namespace Library_Management_Case_Study.Mapping
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, CreateMemberDTO>().ReverseMap();
        }
    }
}
