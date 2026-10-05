using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class BookRepo : Genaricrepo<Book>, IBookRepo
    {
        public BookRepo(AppDbContext context) : base(context)
        {
        }

        public Book GetByTitle(string KeyWord)
        {
            var book = _dbSet.FirstOrDefault(x => x.Title.Contains(KeyWord) || x.Author.Contains(KeyWord));
            return book;
        }

        public Book highestPrice()
        {
            var book = _dbSet.OrderByDescending(x => x.Price).First();
            return book;
        }
    }
}
