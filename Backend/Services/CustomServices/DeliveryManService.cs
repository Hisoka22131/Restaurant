using System.Collections.Generic;
using Backend.Dto.DeliveryMan;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.CustomServices;

public class DeliveryManService : IDeliveryManService
{
    private readonly IUnitOfWork _unitOfWork;
    private IDeliveryManRepository _deliveryManRepository => _unitOfWork.DeliveryManRepository;
    private IRoleRepository _roleRepository => _unitOfWork.RoleRepository;
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
        if (dto?.Id == null && dto?.Id == 0) throw new ArgumentException(null, nameof(dto.Id));
        var entity = _deliveryManRepository.GetDeliveryMan(dto.Id);
        
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

    public async Task CreateDeliveryMan(CreateDeliveryManDto dto)
    {
        if (dto == null) throw new ArgumentException(null, nameof(dto));
        var user = await _authService.Register(dto.Email, dto.Password);
        user.Roles.Add(_roleRepository.GetDeliverymanRole());
        var entity = new DeliveryMan()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Address = dto.Address,
            Birthday = dto.Birthday,
            PhoneNumber = dto.PhoneNumber,
            City = dto.City,
            PassportSeries = dto.PassportSeries,
            User = user,
            DistrictId = dto.DistrictId
        };
        _deliveryManRepository.Insert(entity);
        _unitOfWork.Save();
    }
}