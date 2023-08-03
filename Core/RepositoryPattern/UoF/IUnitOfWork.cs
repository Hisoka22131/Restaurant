using System;
using Core.RepositoryPattern.CustomRepository.Interfaces;

namespace Core.RepositoryPattern.UoF;

public interface IUnitOfWork: IDisposable
{
    IDistrictRepository DistrictRepository { get; set; }
    IOrderRepository OrderRepository { get; set; }
    IDishRepository DishRepository { get; set; }
    IClientRepository ClientRepository { get; set; }
    IDishesOrderRepository DishesOrderRepository { get; set; }
    IDeliveryManRepository DeliveryManRepository { get; set; }
    IUserRepository UserRepository { get; set; }
    IRoleRepository RoleRepository { get; set; }
    int Save();
}