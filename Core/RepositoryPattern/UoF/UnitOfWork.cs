using System;
using Core.Context;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.CustomRepository.Repository;

namespace Core.RepositoryPattern.UoF;

public class UnitOfWork : IUnitOfWork
{
    private readonly RestaurantDbContext _dbContext;

    public UnitOfWork(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(null, nameof(dbContext));
        DistrictRepository = new DistrictRepository(_dbContext);
        OrderRepository = new OrderRepository(_dbContext);
        DishRepository = new DishRepository(_dbContext);
        ClientRepository = new ClientRepository(_dbContext);
        DishesOrderRepository = new DishesOrderRepository(_dbContext);
        DeliveryManRepository = new DeliveryManRepository(_dbContext);
        UserRepository = new UserRepository(_dbContext);
        RoleRepository = new RoleRepository(_dbContext);
    }

    public void Dispose() => _dbContext.Dispose();

    public IDistrictRepository DistrictRepository { get; set; }
    public IOrderRepository OrderRepository { get; set; }
    public IDishRepository DishRepository { get; set; }
    public IClientRepository ClientRepository { get; set; }
    public IDishesOrderRepository DishesOrderRepository { get; set; }
    public IDeliveryManRepository DeliveryManRepository { get; set; }
    public IUserRepository UserRepository { get; set; }
    public IRoleRepository RoleRepository { get; set; }

    public int Save() => _dbContext.SaveChanges();
}