using Library_Management_Case_Study.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_Case_Study.DTO.BorrowingDTO
{
    public class CreateBorrowingDTO
    {
        [Required]
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }
}
