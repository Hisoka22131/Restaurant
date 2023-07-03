using System;
using System.Collections.Generic;
using Backend.Dto.Client;
using Backend.Services.Interfaces;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;

namespace Backend.Services.CustomServices;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private IClientRepository ClientRepository => _unitOfWork.ClientRepository;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<ClientDto>> GetEntities()
    {
        throw new NotImplementedException();
    }

    public async Task<ClientDto> GetEntity(int id)
    {
        throw new NotImplementedException();
    }

    public void PostEntity(ClientDto dto)
    {
        throw new NotImplementedException();
    }

    public void PostDelete(int id)
    {
        throw new NotImplementedException();
    }
}