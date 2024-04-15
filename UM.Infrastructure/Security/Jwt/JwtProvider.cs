using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace UM.Infrastructure.Security.Jwt
{
    public class JwtProvider(IOptions<JwtOptions> options)
        : IJwtProvider
    {
        public string GenerateAccessToken(int userId, string role)
        {
            var secretKey = Encoding.ASCII.GetBytes(options.Value.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim("sub", userId.ToString()),
                    new Claim("role", role)]),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = RandomNumberGenerator.GetBytes(32);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
