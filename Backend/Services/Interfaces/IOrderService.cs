using Backend.Dto.DishOrder;
using Backend.Dto.Order;
using Backend.Services.Base;
using Core.Domain;

namespace Backend.Services.Interfaces;

public interface IOrderService : IBaseService<Order, OrderDto>
{
    Task<IEnumerable<OrderListDto>> Get(int clientId);
    Task CreateOrder(IEnumerable<CreateDishOrderDto> dishOrderDtos);
    Task<IEnumerable<OrderListDto>> GetForAdmin();
}