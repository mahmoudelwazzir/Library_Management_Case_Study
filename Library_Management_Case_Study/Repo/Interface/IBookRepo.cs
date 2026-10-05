using Library_Management_Case_Study.Models;
namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IBookRepo : IGenaricRepo<Book>
    {
        public Book GetByTitle(string KeyWord);
        public Book highestPrice();
    }
}
