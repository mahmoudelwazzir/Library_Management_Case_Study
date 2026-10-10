using Library_Management_Case_Study.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_Case_Study.DTO.BorrowingDTO
{
    public class GetBorrowDTO
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPhone { get; set; }


        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

    }
}
