using Core.Domain.Base;

namespace Core.Domain;

public class User : EntityBase
{
    public User()
    {
        Roles = new HashSet<Role>();
    }

    public string Email { get; set; }
    
    public byte[] Password { get; set; }
    
    public byte[] PasswordKey { get; set; }

    public ICollection<Role> Roles { get; set; }
}