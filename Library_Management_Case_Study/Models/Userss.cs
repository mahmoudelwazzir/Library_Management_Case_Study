using System.ComponentModel.DataAnnotations;

namespace Library_Management_Case_Study.Models
{
    public class Userss
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
