using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

using Core.RepositoryPattern.GenericRepository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    internal OrderRepository(DbContext context) : base(context)
    {
    }

    public Order GetOrder(int id) => GetEntity(c => c.Id == id, c => c.Client, c => c.DishesOrders, c => c.DeliveryMan);
}