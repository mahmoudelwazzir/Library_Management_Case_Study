using Library_Management_Case_Study.DTO.AuthDTO;
using Library_Management_Case_Study.Models;

namespace Library_Management_Case_Study.Repo.Interface
{
    public interface IAuthRepo
    {
        public Task<string> Login(LoginDTO dto);
        public Task<bool> Register(Userss user);
    }
}