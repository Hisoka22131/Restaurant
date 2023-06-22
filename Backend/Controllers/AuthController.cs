using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Dto.Auth.Login;
using Backend.Dto.User;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequestDto request) => await _authService.Login(request);

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto) => await _authService.Register(dto);
}