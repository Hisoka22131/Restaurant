using Backend.Dto.Order;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private IOrderRepository _orderRepository => _unitOfWork.OrderRepository;
    private IClientRepository _clientRepository => _unitOfWork.ClientRepository;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrderDto>> GetEntities() => _orderRepository.GetEntities().Adapt<IEnumerable<OrderDto>>();
    
    public async Task<IEnumerable<OrderListDto>> Get(int clientId)
    {
        var client = _clientRepository.GetClient(clientId);
        return _orderRepository.GetClientOrders(client).Adapt<IEnumerable<OrderListDto>>();
    }

    public async Task<OrderDto> GetEntity(int id) => _orderRepository.GetOrder(id).Adapt<OrderDto>();

    public void PostEntity(OrderDto dto)
    {
        var entity = dto?.Id != null
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