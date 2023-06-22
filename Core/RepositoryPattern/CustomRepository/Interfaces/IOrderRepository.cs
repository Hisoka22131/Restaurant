using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Order GetOrder(int id);
}