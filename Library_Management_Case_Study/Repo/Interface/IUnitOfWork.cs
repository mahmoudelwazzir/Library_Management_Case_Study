using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IUnitOfWork
    {
        public IMemberRepo MemberRepo { get; }
        public IBookRepo Books { get; }
        public ICategoryRepo Categories { get; }
        public IBorrowingRepo Borrowings { get; }
        void save();
    }
}
