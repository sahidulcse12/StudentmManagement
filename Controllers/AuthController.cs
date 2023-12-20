using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentmManagement.DTO;
using StudentmManagement.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentmManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost, Route("login")]
        public IActionResult Login(UserDto user)
        {
            if (user.UserName == "muhit" && user.Password == "muhit123")
            {
                var issuer = "mohamadlawand.com";
                var audience = "mohamadlawand.com";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ijurkbdlhmklqacwqzdxmkkhvqowlyqa"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("ijurkbdlhmklqacwqzdxmkkhvqowlyqa");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", "1"),
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(10),
                    Audience = audience,
                    Issuer = issuer,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = jwtTokenHandler.CreateToken(tokenDescriptor);

                var jwtToken = jwtTokenHandler.WriteToken(token);

                return Ok(jwtToken);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
