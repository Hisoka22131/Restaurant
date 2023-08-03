using Backend.Dto.Base;

namespace Backend.Dto.Order;

public class OrderListDto : EntityDto
{
    public string Number { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountAmount { get; set; }
    public string DeliveryManFirstName { get; set; }
    public string DeliveryManLastName { get; set; }
    public string DeliveryManFullName => DeliveryManFirstName + " " + DeliveryManLastName;
    public string ClientFirstName { get; set; }
    public string ClientLastName { get; set; }
    public string ClientFullName => ClientFirstName + " " + ClientLastName;
}