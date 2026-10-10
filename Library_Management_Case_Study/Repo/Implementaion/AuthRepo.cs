using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library_Management_Case_Study.Data;
using Library_Management_Case_Study.DTO.AuthDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Library_Management_Case_Study.Repo.Implementaion
{
    public class AuthRepo : IAuthRepo
    {
        private AppDbContext _context;
        private IConfiguration _configuration;

        public AuthRepo(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<string> Login(LoginDTO dto)
        {
            var user = await _context.users.FirstOrDefaultAsync(e => e.UserName == dto.UserName);
            if (user == null)
            {
                return null;
            }

            if (user.PasswordHash == dto.PasswordHash)
            {
                return GeneratToken(user);
            }

            return null;
        }

        public async Task<bool> Register(Userss user)
        {
            var exes = await _context.users.AnyAsync(e => e.UserName == user.UserName);
            if (exes)
            {
                return false;
            }

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GeneratToken(Userss user)
        {
            #region user_claim

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            #endregion

            #region key

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:key"]));

            var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            #endregion




            var tokenobj = new JwtSecurityToken(
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:audience"],
                claims:claim,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JWT:ExpireTimeInMinutes"]))
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenobj);
            return token;
        }
    }
}
