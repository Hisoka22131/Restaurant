namespace Backend.Dto.Base;

public class PersonalInfoBaseDto : EntityDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    
    public string Address { get; set; }
    
    public string PassportSeries { get; set; }
    
    public DateTime Birthday { get; set; }
}