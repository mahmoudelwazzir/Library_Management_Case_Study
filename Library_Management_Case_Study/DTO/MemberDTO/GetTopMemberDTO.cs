using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.DTO.MemberDTO
{
    public class GetTopMemberDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Borrowed {  get; set; }
    }
}
