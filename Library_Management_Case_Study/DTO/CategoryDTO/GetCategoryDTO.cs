using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.DTO.CategoryDTO
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBooks { get; set; }
    }
}
