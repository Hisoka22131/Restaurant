using Backend.Dto.Base;

namespace Backend.Dto.DeliveryMan;

public class DeliveryManDto : EntityDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string DistrictName { get; set; }
}