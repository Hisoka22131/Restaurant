using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Context;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public User GetUser(int id) => GetEntity(id);

    public async Task<User?> Authenticate(string email, string password)
    {
        var user = GetEntities().FirstOrDefault(q => q.Email == email);
        if (user?.PasswordKey == null) return null;

        return !MatchPasswordHash(password,  user.Password, user.PasswordKey) ? null : user;
    }

    private static bool MatchPasswordHash(string passwordText, IReadOnlyList<byte> userPassword, byte[] userPasswordKey)
    {
        using var hmac = new HMACSHA512(userPasswordKey);
        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));
        return !passwordHash.Where((t, i) => t != userPassword[i]).Any();
    }

    public void Register(User user, string passwordText)
    {
        using var hmac = new HMACSHA512();
        var passwordKey = hmac.Key;
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordText));

        user.Password = passwordHash;
        user.PasswordKey = passwordKey;
        Insert(user);
    }

    public Task<bool> UserAlreadyInDatabase(string userEmail) => Task.FromResult(GetEntities().Any(q => q.Email == userEmail));
}