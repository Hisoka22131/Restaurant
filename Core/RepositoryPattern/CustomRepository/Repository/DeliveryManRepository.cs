using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class DeliveryManRepository : GenericRepository<DeliveryMan>, IDeliveryManRepository
{
    internal DeliveryManRepository(DbContext context) : base(context)
    {
    }

    public DeliveryMan GetDeliveryMan(int id) =>
        GetEntity(c => c.Id == id, c => c.District, c => c.DeliveryManVacations, c => c.Orders, c => c.User);
}