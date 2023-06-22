using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Repository;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IDishRepository : IGenericRepository<Dish>
{
    Dish GetDish(int id);
}