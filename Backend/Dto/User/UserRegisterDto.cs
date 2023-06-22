using Backend.Dto.Base;

namespace Backend.Dto.User;

public class UserRegisterDto : EntityDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}