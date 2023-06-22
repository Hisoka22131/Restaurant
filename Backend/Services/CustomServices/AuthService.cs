using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Dto.Auth.Login;
using Backend.Dto.User;
using Backend.Helpers;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Backend.Services.CustomServices;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private IUserRepository UserRepository => _unitOfWork.UserRepository;

    public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var user = await UserRepository.Authenticate(request.Email, request.Password);

        // Unauthorized
        if (user == null) return new UnauthorizedResult();

        var response = new LoginResponseDto()
        {
            UserName = user.UserName,
            Token = JwtHelper.CreateJwt(user, _configuration)
        };

        // Ok
        return new OkObjectResult(response);
    }

    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        if (await UserRepository.UserAlreadyInDatabase(dto?.Email) || string.IsNullOrEmpty(dto?.Email))
            return new BadRequestObjectResult("User already exists or user email is null, please try something else");

        var user = new User
        {
            Email = dto.Email,
            UserName = dto.Name
        };

        UserRepository.Register(user, dto.Password);
        _unitOfWork.Save();
        // StatusCode(201)
        return new StatusCodeResult(201);
    }
}