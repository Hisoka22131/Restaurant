using Backend.Dto.Base;

namespace Backend.Dto.Auth.Login;

public class LoginResponseDto : EntityDto
{
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }
}