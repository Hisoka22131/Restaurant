using Backend.Dto.Base;

namespace Backend.Dto.DeliveryMan;

public class DeliveryManDto : PersonalInfoBaseDto
{
    public int DistrictId { get; set; }
}