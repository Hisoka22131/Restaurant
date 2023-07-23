using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class DishesOrderRepository : GenericRepository<DishOrder>, IDishesOrderRepository
{
    internal DishesOrderRepository(DbContext context) : base(context)
    {
    }

    public DishOrder GetDishesOrder(int id) => GetEntity(c => c.Id == id, c => c.Order, c => c.Dish);
}