using System.Security.Claims;
using Backend.Dto.DishOrder;
using Backend.Dto.Order;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.Enums;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class OrderService : IOrderService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IUnitOfWork _unitOfWork;
    private IOrderRepository _orderRepository => _unitOfWork.OrderRepository;
    private IClientRepository _clientRepository => _unitOfWork.ClientRepository;
    private IDeliveryManRepository _deliveryManRepository => _unitOfWork.DeliveryManRepository;
    private IUserService _userService;
    private IDishRepository _dishRepository => _unitOfWork.DishRepository;

    public OrderService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public async Task<IEnumerable<OrderDto>> GetEntities() => _orderRepository.GetEntities().Adapt<IEnumerable<OrderDto>>();
    
    public async Task<IEnumerable<OrderListDto>> Get(int userId)
    {
        var user = await _userService.GetUserFromHttp();
        if (user.Roles.Any(q => q.Name == Role.Admin))
            return await GetForAdmin();
        return _orderRepository.GetClientOrders(user).Adapt<IEnumerable<OrderListDto>>();
    }

    public async Task<IEnumerable<OrderListDto>> GetForAdmin() => _orderRepository.GetIncludeOrders().Adapt<IEnumerable<OrderListDto>>();

    public async Task CreateOrder(IEnumerable<CreateDishOrderDto> dishOrderDtos)
    {
        if (!dishOrderDtos.Any()) throw new ArgumentException("Заказ пуст");
        var user = await _userService.GetUserFromHttp();
        var order = new Order
        {
            Number = new Random().Next(100000, 999999).ToString(),
            Type = TypeOrder.Site,
            Client = _clientRepository.GetEntities().FirstOrDefault(q => q.User == user )!
        };
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