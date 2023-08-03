using Backend.Dto.Base;

namespace Backend.Dto.DeliveryMan;

public class CreateDeliveryManDto : PersonalInfoBaseDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public int DistrictId { get; set; }
    
}