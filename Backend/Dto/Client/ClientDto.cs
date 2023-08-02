using Backend.Dto.Base;

namespace Backend.Dto.Client;

public class ClientDto : PersonalInfoBaseDto
{
    public int? DiscountPercentage { get; set; }
}