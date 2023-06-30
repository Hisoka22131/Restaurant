using Backend.Dto.Order;
using Backend.Services.Base;
using Core.Domain;

namespace Backend.Services.Interfaces;

public interface IOrderService : IBaseService<Order, OrderDto>
{
    IEnumerable<OrderListDto> Get(int clientId);
}