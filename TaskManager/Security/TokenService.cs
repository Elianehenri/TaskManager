using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Security
{
    public class TokenService
    {
        public static string GenerateToken(User user, string jwtKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Certifique-se de usar uma chave secreta forte e segura
            var secretKey = Encoding.ASCII.GetBytes(jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //propriedades de segurança do token
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),

                }),
                 
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // Cria o token
            return tokenHandler.WriteToken(token); // Retorna o token
        }
    }
}
