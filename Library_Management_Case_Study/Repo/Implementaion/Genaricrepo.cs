using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class Genaricrepo<T> : IGenaricRepo<T> where T : class
    {
        protected readonly AppDbContext _Context;
        protected readonly DbSet<T> _dbSet;
        public Genaricrepo(AppDbContext context)
        {
            _Context = context;
            _dbSet = _Context.Set<T>();
        }

        public void AddItem(T item)
        {
            _dbSet.Add(item);
        }

        public void DeleteItem(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
           return _dbSet.Find(id);
        }

        public void UpdateItem(T item)
        {
            _dbSet.Update(item);
        }
    }
}
