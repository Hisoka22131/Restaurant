using System.Collections.Generic;
using Backend.Dto.Order;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.CustomRepository.Repository;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private IOrderRepository OrderRepository => _unitOfWork.OrderRepository;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<OrderDto> GetEntities() => OrderRepository.GetEntities().Adapt<IEnumerable<OrderDto>>();

    public OrderDto GetEntity(int id) => OrderRepository.GetOrder(id).Adapt<OrderDto>();

    public void PostEntity(OrderDto dto)
    {
        var entity = dto?.Id != null
            ? OrderRepository.GetOrder(dto.Id)
            : new Order();

        entity.Number = dto.Number;
        entity.Type = dto.Type;
        entity.DiscountAmount = dto.DiscountAmount;
        entity.Price = dto.Price;
    }

    public void PostDelete(int id)
    {
        var entity = OrderRepository.GetOrder(id);
        OrderRepository.Remove(entity);
        _unitOfWork.Save();
    }
}