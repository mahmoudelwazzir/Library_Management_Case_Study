using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IMemberRepo memberRepo, IBookRepo books, ICategoryRepo categories, IBorrowingRepo borrowings)
        {
            _context = context;
            MemberRepo = memberRepo;
            Books = books;
            Categories = categories;
            Borrowings = borrowings;
        }

        public IMemberRepo MemberRepo { get; }
        public IBookRepo Books { get; }
        public ICategoryRepo Categories { get; }
        public IBorrowingRepo Borrowings { get; }

        public void save()
        {
             _context.SaveChanges();
        }
    }
}
