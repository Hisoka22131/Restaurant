using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class DishRepository : GenericRepository<Dish>, IDishRepository
{
    internal DishRepository(DbContext context) : base(context)
    {
    }

    public Dish GetDish(int id) => GetEntity(c => c.Id == id, c => c.DishesOrders);
}