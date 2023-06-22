using Backend.Dto.Base;
using Core.Enums;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace Backend.Dto.Order;

public class OrderDto : EntityDto
{
    public string Number { get; set; }
    public TypeOrder Type { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountAmount { get; set; }
    public string ClientName { get; set; }
}