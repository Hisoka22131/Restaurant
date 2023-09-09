using System.Threading.Tasks;
using Backend.Dto.Auth.Login;
using Backend.Dto.User;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Interfaces;

public interface IAuthService
{
    Task<IActionResult> Login(LoginRequestDto request, HttpContext httpContext);
    Task<IActionResult> Logout(HttpContext httpContext);
    Task<User> Register(string email, string password);
    Task<IActionResult> RegisterClient(UserRegisterDto dto);
    Task<string> CreateToken(User user);
}