using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(DbContext context) : base(context)
    {
    }

    public Role GetAdminRole() => GetEntities().First(q => q.Name == Role.Admin);

    public Role GetClientRole() => GetEntities().First(q => q.Name == Role.Client);

    public Role GetDeliverymanRole() => GetEntities().First(q => q.Name == Role.DeliveryMan);
}