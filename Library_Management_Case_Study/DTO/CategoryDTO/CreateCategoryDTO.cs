using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.DTO.CategoryDTO
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
