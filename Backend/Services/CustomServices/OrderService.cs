using Backend.Dto.DishOrder;
using Backend.Dto.Order;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.Enums;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class DishOrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private IOrderRepository _orderRepository => _unitOfWork.OrderRepository;
    private IClientRepository _clientRepository => _unitOfWork.ClientRepository;
    private IDeliveryManRepository _deliveryManRepository => _unitOfWork.DeliveryManRepository;
    private IDishRepository _dishRepository => _unitOfWork.DishRepository;

    public DishOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrderDto>> GetEntities() => _orderRepository.GetEntities().Adapt<IEnumerable<OrderDto>>();
    
    public async Task<IEnumerable<OrderListDto>> Get(int clientId)
    {
        var client = _clientRepository.GetClient(clientId);
        return _orderRepository.GetClientOrders(client).Adapt<IEnumerable<OrderListDto>>();
    }

    public void CreateOrder(IEnumerable<CreateDishOrderDto> dishOrderDtos)
    {
        if (!dishOrderDtos.Any()) throw new ArgumentException("Заказ пуст");
        var order = new Order();
        order.Number = new Random().Next(100000, 999999).ToString();
        order.Type = TypeOrder.Site;
        order.ClientId = 2;
        var tupleIds = _deliveryManRepository.GetMaxMinId();
        order.DeliveryManId = new Random().Next(tupleIds.min, tupleIds.max);
        SetDish(order, dishOrderDtos);
        _orderRepository.Insert(order);
        _unitOfWork.Save();
    }

    private void SetDish(Order order, IEnumerable<CreateDishOrderDto> dishOrderDtos)
    {
        decimal price = 0;
        foreach (var dishOrderDto in dishOrderDtos)
        {
            var dish = _dishRepository.GetDish(dishOrderDto.DishId);
            var dishOrder = new DishOrder()
            {
                Dish = dish,
                Order = order,
                Count = dishOrderDto.Count
            };
            price += dish.Price * dishOrder.Count;
            order.DishesOrders.Add(dishOrder);
        }
        order.Price = price;
    }

    public async Task<OrderDto> GetEntity(int id) => _orderRepository.GetOrder(id).Adapt<OrderDto>();

    public void PostEntity(OrderDto dto)
    {
        var entity = dto?.Id != null && dto?.Id != 0
            ? _orderRepository.GetOrder(dto.Id)
            : new Order();

        entity.Number = dto.Number;
        entity.Type = dto.Type;
        entity.DiscountAmount = dto.DiscountAmount;
        entity.Price = dto.Price;
    }

    public void PostDelete(int id)
    {
        var entity = _orderRepository.GetOrder(id);
        _orderRepository.Remove(entity);
        _unitOfWork.Save();
    }
}