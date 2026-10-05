using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IUnitOfWork
    {
        public IGenaricRepo<Member> Members { get; }
        public IBookRepo Books { get; }
        public ICategoryRepo Categories { get; }
        public IGenaricRepo<Borrowing> Borrowings { get; }
        void save();
    }
}
