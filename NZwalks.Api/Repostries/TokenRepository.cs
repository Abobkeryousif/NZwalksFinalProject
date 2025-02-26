using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZwalks.Api.Repostries
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(IdentityUser user, List<string> Roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email , user.Email));
            foreach (var role in Roles) 
            {
            claims.Add(new Claim(ClaimTypes.Role , role)); 
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var cerdintail = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                _configuration["Jwt:Issure"],
                _configuration["Jwt:Audience"],
                claims,
                signingCredentials : cerdintail,
                expires : DateTime.UtcNow.AddMinutes(15)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
