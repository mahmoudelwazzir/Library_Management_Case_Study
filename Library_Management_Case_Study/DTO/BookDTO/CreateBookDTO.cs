using Library_Management_Case_Study.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_Case_Study.DTO.BookDTO
{
    public class CreateBookDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required, Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int CategoryId { get; set; }
    }
}
