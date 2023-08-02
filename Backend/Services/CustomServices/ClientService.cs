﻿using System;
using System.Collections.Generic;
using Backend.Dto.Client;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;

namespace Backend.Services.CustomServices;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private IClientRepository _clientRepository => _unitOfWork.ClientRepository;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ClientDto>> GetEntities() =>
        _clientRepository.GetEntities().Adapt<IEnumerable<ClientDto>>();

    public async Task<ClientDto> GetEntity(int id) =>
        _clientRepository.GetClient(id).Adapt<ClientDto>();

    public void PostEntity(ClientDto dto)
    {
        var entity = dto?.Id != null && dto?.Id != 0
            ? _clientRepository.GetClient(dto.Id)
            : new Client();

        entity.FirstName = dto.FirstName;
        entity.LastName = dto.LastName;
        entity.PhoneNumber = dto.PhoneNumber;
        entity.City = dto.City;
        entity.Address = dto.Address;
        entity.Birthday = dto.Birthday;
        entity.PassportSeries = dto.PassportSeries;
        entity.DiscountPercentage = dto.DiscountPercentage;

        _clientRepository.InsertOrUpdate(entity);
        _unitOfWork.Save();
    }

    public void PostDelete(int id)
    {
        var entity = _clientRepository.GetClient(id);
        _clientRepository.Remove(entity);
        _unitOfWork.Save();
    }
}