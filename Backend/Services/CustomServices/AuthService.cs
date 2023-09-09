using Backend.Dto.Auth.Login;
using Backend.Dto.User;
using Backend.Helpers;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.CustomServices;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private IUserRepository _userRepository => _unitOfWork.UserRepository;
    private readonly IClientService _clientService;

    public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, IClientService clientService)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
        _clientService = clientService;
    }

    public async Task<IActionResult> Login(LoginRequestDto request, HttpContext httpContext)
    {
        var user = await _userRepository.Authenticate(request.Email, request.Password);
        if (user == null) return new UnauthorizedObjectResult("Введите валидные данные");
        
        var response = new LoginResponseDto()
        {
            Id = user.Id,
            Email = user.Email,
            Roles = user.Roles.Select(q => q.Name)
        };
        
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddMinutes(30),
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        httpContext.Response.Cookies.Append("restCookie", JwtHelper.CreateJwt(user, _configuration), cookieOptions);
        return new ObjectResult(response);
    }

    public async Task<IActionResult> Logout(HttpContext httpContext)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(-1),
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        httpContext.Response.Cookies.Delete("restCookie", cookieOptions);
        return new OkResult();
    }

    public async Task<string> CreateToken(User user) => JwtHelper.CreateJwt(user, _configuration);
    
    public async Task<User> Register(string email, string password)
    {
        if (await _userRepository.UserAlreadyInDatabase(email) || string.IsNullOrEmpty(email))
            throw new ArgumentException("User already exists or user email is null, please try something else");

        var user = new User
        {
            Email = email
        };
        _userRepository.Register(user, password);
        return user;
    }

    public async Task<IActionResult> RegisterClient(UserRegisterDto dto)
    {
        _clientService.CreateClient(await Register(dto.Email, dto.Password), dto);
        return new StatusCodeResult(201);
    }
}