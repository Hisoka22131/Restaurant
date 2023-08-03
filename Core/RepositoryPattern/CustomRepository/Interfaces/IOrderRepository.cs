using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Order GetOrder(int id);
    IEnumerable<Order> GetIncludeOrders();
    IEnumerable<Order> GetClientOrders(Client client);
    IEnumerable<Order> GetClientOrders(int clientId);
    IEnumerable<Order> GetClientOrders(User user);
}