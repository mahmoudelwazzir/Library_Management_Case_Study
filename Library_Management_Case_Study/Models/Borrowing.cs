using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_Case_Study.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }
        public Member member { get; set; }
        [ForeignKey("member")]
        public int MemberId { get; set; }
        public Book book { get; set; }
        [ForeignKey("book")]
        public int BookId { get; set; }
    }
}
