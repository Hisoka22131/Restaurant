using System.Security.Claims;
using Backend.Dto.User;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IUnitOfWork _unitOfWork;
    private IUserRepository _userRepository => _unitOfWork.UserRepository;

    public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public Task<IEnumerable<UserDto>> GetEntities()
    {
        throw new NotImplementedException();
    }

    
    public async Task<User> GetUserFromHttp()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) throw new ArgumentException(null, nameof(userId));

        return _userRepository.GetUser(int.Parse(userId));
    }
    
    public async Task<UserDto> GetEntity(int id) => _userRepository.GetUser(id).Adapt<UserDto>();

    public void PostEntity(UserDto dto)
    {
        throw new NotImplementedException();
    }

    public void PostDelete(int id)
    {
        throw new NotImplementedException();
    }
}