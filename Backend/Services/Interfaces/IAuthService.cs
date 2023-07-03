using System.Threading.Tasks;
using Backend.Dto.Auth.Login;
using Backend.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Interfaces;

public interface IAuthService
{
    Task<IActionResult> Login(LoginRequestDto request); 
    Task<IActionResult> Register(UserRegisterDto dto);
}