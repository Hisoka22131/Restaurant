using Backend.Dto.Auth.Login;
using Backend.Dto.User;
using Backend.Helpers;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.CustomServices;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private IUserRepository _userRepository => _unitOfWork.UserRepository;
    private IClientRepository _clientRepository => _unitOfWork.ClientRepository;
    private IRoleRepository _roleRepository => _unitOfWork.RoleRepository;
    private IClientService _clientService;

    public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, IClientService clientService)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
        _clientService = clientService;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto request)
    {
        var user = await _userRepository.Authenticate(request.Email, request.Password);

        // Unauthorized
        if (user == null) return null;

        var response = new LoginResponseDto()
        {
            Id = user.Id,
            Email = user.Email,
            Token = JwtHelper.CreateJwt(user, _configuration)
        };

        // Ok
        return response;
    }
    
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