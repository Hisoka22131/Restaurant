using Backend.Dto.Auth.Login;
using Backend.Dto.User;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequestDto request) => await _authService.Login(request, HttpContext);


    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout() => await _authService.Logout(HttpContext);

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto) => await _authService.RegisterClient(dto);

    [HttpPut]
    [Route("change-password")]
    public async Task ChangePassword(UserChangePasswordDto dto) => await _authService.ChangePassword(dto);
}