using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Library_Management_Case_Study.DTO.AuthDTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
