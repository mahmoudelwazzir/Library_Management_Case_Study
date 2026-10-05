using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class MemberRepo : Genaricrepo<Member>, IMemberRepo
    {
        public MemberRepo(AppDbContext context) : base(context)
        {
        }

        public ICollection<Member> Gettopfivemember()
        {
            throw new NotImplementedException();
        }
    }
}
