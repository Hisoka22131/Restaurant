using System.Collections.Generic;
using Backend.Dto.DeliveryMan;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class DeliveryManService : IDeliveryManService
{
    private readonly IUnitOfWork _unitOfWork;
    private IDeliveryManRepository DeliveryManRepository => _unitOfWork.DeliveryManRepository;

    public DeliveryManService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<DeliveryManDto> GetEntities() =>
        DeliveryManRepository.GetEntities().Adapt<IEnumerable<DeliveryManDto>>();

    public DeliveryManDto GetEntity(int id) => DeliveryManRepository.GetDeliveryMan(id).Adapt<DeliveryManDto>();

    public void PostEntity(DeliveryManDto dto)
    {
        var entity = dto?.Id != null
            ? DeliveryManRepository.GetDeliveryMan(dto.Id)
            : new DeliveryMan();

        entity.FirstName = dto.FirstName;
        entity.LastName = dto.LastName;
        entity.PhoneNumber = dto.PhoneNumber;
        entity.City = dto.City;
        entity.Address = dto.Address;
        entity.Birthday = dto.Birthday;
        entity.PassportSeries = dto.PassportSeries;
        
        DeliveryManRepository.InsertOrUpdate(entity);
        _unitOfWork.Save();
    }

    public void PostDelete(int id)
    {
        var entity = DeliveryManRepository.GetDeliveryMan(id);
        DeliveryManRepository.Remove(entity);
        _unitOfWork.Save();
    }
}