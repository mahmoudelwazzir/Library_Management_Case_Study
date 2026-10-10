using System.Xml;
using Library_Management_Case_Study.DTO.AuthDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_Case_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepo _repo;

        public AuthController(IAuthRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _repo.Login(dto);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var user = new Userss()
            {
                UserName = dto.UserName,
                Role = dto.Role,
                PasswordHash = dto.PasswordHash,
            };
             
            var ex = await _repo.Register(user);
            if (ex)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
