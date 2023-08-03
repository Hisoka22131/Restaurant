using Backend.Dto.Base;
using Backend.Dto.Role;

namespace Backend.Dto.User;

public class UserDto : EntityDto
{
    public string Email { get; set; }
    public RoleDto[] Roles { get; set; }
}