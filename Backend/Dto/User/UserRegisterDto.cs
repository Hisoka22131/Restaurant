using Backend.Dto.Base;

namespace Backend.Dto.User;

public class UserRegisterDto : PersonalInfoBaseDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}