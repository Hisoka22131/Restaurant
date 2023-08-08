using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Helpers;

public static class JwtHelper
{
    internal static string CreateJwt(User user, IConfiguration configuration)
    {
        var secretKey = configuration.GetSection("Appsettings:Key").Value;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var claims = new List<Claim>()
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}