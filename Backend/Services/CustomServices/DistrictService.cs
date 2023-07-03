using System;
using System.Collections.Generic;
using Backend.Dto.District;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class DistrictService : IDistrictService
{
    private readonly IUnitOfWork _unitOfWork;
    private IDistrictRepository DistrictRepository => _unitOfWork.DistrictRepository;

    public DistrictService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DistrictDto>> GetEntities() => DistrictRepository.GetEntities().Adapt<IEnumerable<DistrictDto>>();

    public async Task<DistrictDto> GetEntity(int id)
    {
        if (id == 0) throw new ArgumentException("id is not exists");
        var district = DistrictRepository.GetDistrict(id);
        var districtDto = district.Adapt<DistrictDto>();
        return districtDto;
    }

    public void PostEntity(DistrictDto dto)
    {
        var entity = dto?.Id != null
            ? DistrictRepository.GetDistrict(dto.Id)
            : new District();

        entity.Name = dto.Name;
        DistrictRepository.InsertOrUpdate(entity);
        _unitOfWork.Save();
    }

    public void PostDelete(int id)
    {
        var entity = DistrictRepository.GetDistrict(id);
        DistrictRepository.Remove(entity);
        _unitOfWork.Save();
    }
}