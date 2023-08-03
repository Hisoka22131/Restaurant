using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IRoleRepository : IGenericRepository<Role>
{
    Role GetAdminRole();
    Role GetClientRole();
    Role GetDeliverymanRole();
}