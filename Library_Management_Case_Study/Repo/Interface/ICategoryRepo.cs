using Library_Management_Case_Study.DTO.BookDTO;
using Library_Management_Case_Study.DTO.CategoryDTO;
using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Repo.Interface
{
    public interface ICategoryRepo : IGenaricRepo<Category>
    {
        ICollection<GetCategoryDTO> GetAllCategory();
        bool DeleteCategory(int id);
    }
}
