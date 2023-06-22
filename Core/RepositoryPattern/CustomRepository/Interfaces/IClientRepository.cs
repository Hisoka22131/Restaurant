using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IClientRepository : IGenericRepository<Client>
{
    Client GetClient(int id);
}