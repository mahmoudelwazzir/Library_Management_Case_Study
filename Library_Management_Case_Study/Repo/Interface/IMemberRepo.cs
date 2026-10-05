
using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IMemberRepo : IGenaricRepo<Member>
    {
        ICollection<Member> Gettopfivemember();
    }
}
