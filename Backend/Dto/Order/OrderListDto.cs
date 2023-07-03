using Backend.Dto.Base;

namespace Backend.Dto.Order;

public class OrderListDto : EntityDto
{
    public string Number { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountAmount { get; set; }
    public string DeliveryManName { get; set; }
}