using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_Case_Study.Models
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required, Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Category category { get; set; }
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
