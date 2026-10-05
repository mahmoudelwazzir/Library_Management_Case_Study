using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.DTO.CategoryDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.Frozen;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class CategoryRepo : Genaricrepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }

        public bool DeleteCategory(int id)
        {
            if (id == null)
            {
                return false;
            }
            var cate = _dbSet.Include(b => b.Books).FirstOrDefault(x => x.Id == id);
            if (cate.Books.Count() == 0)
            {
                _dbSet.Remove(cate);
                return true;
            }
            return false;
        }

        public ICollection<GetCategoryDTO> GetAllCategory()
        {
            return _dbSet.Include(x => x.Books).Select(y => new GetCategoryDTO
            {
                Id = y.Id,
                Name = y.Name,
                NumberOfBooks = y.Books.Count,
            }).ToList();
        }
    }
}
