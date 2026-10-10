using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.DTO.MemberDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class MemberRepo : Genaricrepo<Member>, IMemberRepo
    {
        public MemberRepo(AppDbContext context) : base(context)
        {
        }

        public GetMemberDTO GetMemberById(int id)
        {
            return _dbSet
                 .Where(x => x.Id == id)
                 .Select(m => new GetMemberDTO
                 {
                     FullName = m.FullName,
                     TotalBorriwedBooks = m.Borrowings.Count(),
                     ReturnBooks = m.Borrowings.Where(y => y.ReturnDate != null).Count(),
                     CurrentlyBorrowedBooks = m.Borrowings.Where(z => z.ReturnDate == null).Count()
                 }).FirstOrDefault();
        }

        public ICollection<GetTopMemberDTO> Gettopfivemember()
        {
            var member = _dbSet.Select(r => new GetTopMemberDTO { FullName = r.FullName, Id = r.Id, Borrowed = r.Borrowings.Count }).OrderByDescending(r => r.Borrowed).Take(5).ToList();
            return member;
        }
    }
}
