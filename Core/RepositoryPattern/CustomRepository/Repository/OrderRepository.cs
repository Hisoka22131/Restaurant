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

    public IEnumerable<Order> GetIncludeOrders() => GetEntities(q => q.DeliveryMan, q => q.Client);
    
    public IEnumerable<Order> GetClientOrders(Client client) => GetIncludeOrders().Where(q => q.Client == client);

    public IEnumerable<Order> GetClientOrders(int clientId) => GetIncludeOrders().Where(q => q.ClientId == clientId);
    public IEnumerable<Order> GetClientOrders(User user) => GetIncludeOrders().Where(q => q.Client.UserId == user.Id);
}