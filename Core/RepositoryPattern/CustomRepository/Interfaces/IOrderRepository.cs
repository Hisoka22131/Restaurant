using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Order GetOrder(int id);
    IEnumerable<Order> GetOrders();
    IEnumerable<Order> GetClientOrders(Client client);
    IEnumerable<Order> GetClientOrders(int clientId);
}