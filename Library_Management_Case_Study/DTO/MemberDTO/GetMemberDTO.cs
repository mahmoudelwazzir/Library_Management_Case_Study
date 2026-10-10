using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.DTO.MemberDTO
{
    public class GetMemberDTO
    {
        public string FullName { get; set; }
        public int TotalBorriwedBooks { get; set; }
        public int ReturnBooks { get; set; }
        public int CurrentlyBorrowedBooks {  get; set; }
    }
}
