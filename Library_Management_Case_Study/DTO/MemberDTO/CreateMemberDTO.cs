using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.DTO.MemberDTO
{
    public class CreateMemberDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
