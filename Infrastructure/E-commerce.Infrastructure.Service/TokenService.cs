using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Service
{
    public class TokenService(IOptions<JWTOptions> options) : ITokenService
    {
        
        public string GetToken(ApplicationUser user , IList<string> roles)
        {
           
            List<Claim> claims = [
                new (JwtRegisteredClaimNames.Name,user.DisplayName),
                 new (JwtRegisteredClaimNames.Email,user.Email)


                ];
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyApiProjectMyApiProjectMyApiProject"));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims : claims,
                
                issuer: "My-Api-Project",
                audience: "My-Api-Project",
                expires:DateTime.Now.AddHours(1),
                signingCredentials:creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
