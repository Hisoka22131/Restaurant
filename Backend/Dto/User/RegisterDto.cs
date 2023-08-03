using Backend.Dto.Base;

namespace Backend.Dto.User;

public class RegisterDto : EntityDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}