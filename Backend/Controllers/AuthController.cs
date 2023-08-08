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
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var response = await _authService.Login(request);
        if (response == null) return Ok("Введите валидные данные");
        
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddMinutes(30),
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        HttpContext.Response.Cookies.Append("restCookie", response.Token, cookieOptions);
        
        return new OkObjectResult(new {response.Id, response.Email});
    }
    
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(-1),
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        HttpContext.Response.Cookies.Delete("restCookie", cookieOptions);
        return Ok();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto) => await _authService.RegisterClient(dto);
}