using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.DTO.BookDTO
{
    public class GetBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}
