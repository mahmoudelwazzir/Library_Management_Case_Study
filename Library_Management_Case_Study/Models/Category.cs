using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
