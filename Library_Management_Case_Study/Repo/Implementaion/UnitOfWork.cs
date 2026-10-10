using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IGenaricRepo<Member> members
            , IBookRepo books
            , ICategoryRepo categories
            , IGenaricRepo<Borrowing> borrowings)
        {
            _context = context;
            Members = members;
            Books = books;
            Categories = categories;
            Borrowings = borrowings;
        }

        public IGenaricRepo<Member> Members { get; }
        public IBookRepo Books { get; }
        public ICategoryRepo Categories { get; }
        public IGenaricRepo<Borrowing> Borrowings { get; }

        public void save()
        {
             _context.SaveChanges();
        }
    }
}
