
using Library_Management_Case_Study.DTO.MemberDTO;
using Library_Management_Case_Study.Models;
using System.Dynamic;

namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IMemberRepo : IGenaricRepo<Member>
    {
        ICollection<GetTopMemberDTO> Gettopfivemember();
        GetMemberDTO GetMemberById(int id);
    }
}
