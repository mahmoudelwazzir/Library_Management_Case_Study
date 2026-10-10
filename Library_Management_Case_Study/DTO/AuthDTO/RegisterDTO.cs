using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.DTO.AuthDTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
