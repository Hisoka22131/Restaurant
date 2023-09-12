using Backend.Dto.Base;

namespace Backend.Dto.User;

public class UserChangePasswordDto : EntityDto
{
    public string Password { get; set; }
}