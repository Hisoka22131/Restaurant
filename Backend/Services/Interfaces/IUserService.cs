using Backend.Dto.User;
using Backend.Services.Base;
using Core.Domain;

namespace Backend.Services.Interfaces;

public interface IUserService : IBaseService<User, UserDto>
{
    Task<User> GetUserFromHttp();
}