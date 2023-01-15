using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ms_partnership.Data;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Security;

namespace ms_partnership.Controllers.Security
{
    [Route("[controller]")]
    [ApiController]
    public class LoginManagementController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public LoginManagementController(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult LoginUsuario([FromBody] LoginModel doinglogin)
        {
            Login login = _context.Logins.FirstOrDefault(login => login.Email == doinglogin.Username);

            var failReturn = Unauthorized("Invalid username or password");

            if (login == null)
            {
                return failReturn;
            }

            if (doinglogin.Password == login.Password)
            {
                var tokenString = TokenBear(login);
                return Ok(new { token = tokenString });
            }
            return failReturn;
        }

        private string TokenBear(Login login)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var identity = Claims(login);

            var token =
                new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    claims: identity,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddHours(1)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Claim[] Claims(Login login)
        {
            return new[] {
                        new Claim("id", login.Id.ToString()),
                        new Claim("username", login.Email),
                        new Claim("password", login.Password),
                        new Claim("role", login.Role),
                        new Claim("professional", login.Professional.ToString()),
                        new Claim("companyId", login.CompanyId.ToString()),
                        new Claim("userId", login.UserId.ToString())
                    };
        }
    }
}