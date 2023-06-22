using Core.Domain.Base;

namespace Core.Domain;

public class User : EntityBase
{
    public string Email { get; set; }
    
    public byte[] Password { get; set; }
    
    public byte[] PasswordKey { get; set; }
    
    public string UserName { get; set; }
}