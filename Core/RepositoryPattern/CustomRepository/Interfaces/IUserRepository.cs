using System.Threading.Tasks;
using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    User GetUser(int id);
    
    Task<User?> Authenticate(string email, string password);
    
    Task Register(User user, string passwordText);

    Task<bool> UserAlreadyInDatabase(string userEmail);

    Task ChangePassword(User user, string passwordText);

}