using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.DTO.BorrowingDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class BorrowingRepo : Genaricrepo<Borrowing>, IBorrowingRepo
    {
        public BorrowingRepo(AppDbContext context) : base(context)
        {
        }

        public Borrowing CreateBorrowing(int bookId, int memberId)
        {
            var borrowing = new Borrowing()
            {
                MemberId = memberId,
                BookId = bookId,
                BorrowDate = DateTime.Now,
                ReturnDate = null
            };
            AddItem(borrowing);
            return borrowing;   
        }

        public ICollection<GetBorrowDTO> GetAllBorrowing()
        {
            return _dbSet
                .OrderByDescending(b => b.BorrowDate)
                .Select(b => new GetBorrowDTO
                {
                    Id = b.Id,
                    BorrowDate = b.BorrowDate,
                    ReturnDate= b.ReturnDate,
                    MemberId = b.MemberId,
                    MemberName = b.member.FullName,
                    MemberEmail = b.member.Email,
                    MemberPhone = b.member.Phone,
                    BookId = b.BookId,
                    Author = b.book.Author,
                    Title = b.book.Title
                }).ToList();
        }

        public bool ReturnBook(int borrowingid)
        {
            var borrowing = _dbSet.Include(b => b.book) .FirstOrDefault(b => b.Id == borrowingid);
            if(borrowing == null || borrowing.ReturnDate != null) { return false; }
            borrowing.ReturnDate = DateTime.Now;
            var book = _dbSet.FirstOrDefault(b => b.Id == borrowing.BookId);
            if(borrowing.book != null) { borrowing.book.IsAvailable = true; }
            return true;
        }
    }
}
