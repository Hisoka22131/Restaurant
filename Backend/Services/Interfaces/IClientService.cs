﻿using Backend.Dto.Base;
using Backend.Dto.Client;
using Backend.Services.Base;
using Core.Domain;

namespace Backend.Services.Interfaces;

public interface IClientService : IBaseService<Client, ClientDto>
{
    void CreateClient(User user, PersonalInfoBaseDto dto);
}