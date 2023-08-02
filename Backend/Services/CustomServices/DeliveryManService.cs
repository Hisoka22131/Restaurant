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
    private IDeliveryManRepository _deliveryManRepository => _unitOfWork.DeliveryManRepository;
    private IAuthService _authService;

    public DeliveryManService(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<IEnumerable<DeliveryManDto>> GetEntities() =>
        _deliveryManRepository.GetEntities().Adapt<IEnumerable<DeliveryManDto>>();

    public async Task<DeliveryManDto> GetEntity(int id) =>
        _deliveryManRepository.GetDeliveryMan(id).Adapt<DeliveryManDto>();

    public void PostEntity(DeliveryManDto dto)
    {
        var entity = dto?.Id != null && dto?.Id != 0
            ? _deliveryManRepository.GetDeliveryMan(dto.Id)
            : new DeliveryMan();

        entity.FirstName = dto.FirstName;
        entity.LastName = dto.LastName;
        entity.PhoneNumber = dto.PhoneNumber;
        entity.City = dto.City;
        entity.Address = dto.Address;
        entity.Birthday = dto.Birthday;
        entity.PassportSeries = dto.PassportSeries;
        if (dto.DistrictId != 0)
            entity.DistrictId = dto.DistrictId;
        
        _deliveryManRepository.InsertOrUpdate(entity);
        _unitOfWork.Save();
    }

    public void PostDelete(int id)
    {
        var entity = _deliveryManRepository.GetDeliveryMan(id);
        _deliveryManRepository.Remove(entity);
        _unitOfWork.Save();
    }

    public void CreateDeliveryMan()
    {
        
    }
}