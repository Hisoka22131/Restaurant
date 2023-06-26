namespace Core.Domain.Base;

public class PersonalInfoBase : EntityBase
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;
    
    public DateTime Birthday { get; set; } 
    
    public string City { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    public string PassportSeries { get; set; } = null!;
    
    public int UserId { get; set; }

    public User User { get; set; } = null!;

}