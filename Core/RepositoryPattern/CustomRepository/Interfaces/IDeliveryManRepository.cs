using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IDeliveryManRepository : IGenericRepository<DeliveryMan>
{
    DeliveryMan GetDeliveryMan(int id);
}