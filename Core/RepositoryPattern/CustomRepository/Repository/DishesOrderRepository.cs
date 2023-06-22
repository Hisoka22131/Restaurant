using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class DishesOrderRepository : GenericRepository<DishesOrder>, IDishesOrderRepository
{
    internal DishesOrderRepository(DbContext context) : base(context)
    {
    }

    public DishesOrder GetDishesOrder(int id) => GetEntity(c => c.Id == id, c => c.Order, c => c.Dishes);
}