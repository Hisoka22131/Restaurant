using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class ClientRepository : GenericRepository<Client> , IClientRepository
{
    internal ClientRepository(DbContext context) : base(context)
    {
    }
    
    public Client GetClient(int id) => GetEntity(c => c.Id == id, c => c.Orders, c => c.User);

}