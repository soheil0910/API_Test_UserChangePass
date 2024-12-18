﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Test_UserChangePass.Utility
{
    public class TokenService
    {



        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string username, string Email, string RegisterDate,string IsAdmin)
        {
            var claims = new[]
            {
            new Claim("UserName", username),
            new Claim(JwtRegisteredClaimNames.Email, Email),
            new Claim("RegisterDate", RegisterDate),
            new Claim("IsAdmin", IsAdmin),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_config["Jwt:ExpiresInMinutes"])),
                //expires: DateTime.Now.AddDays(int.Parse(_config["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }








    }
}
