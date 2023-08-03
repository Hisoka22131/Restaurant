using Backend.Dto.Client;
using Backend.Services.Interfaces;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    
    public ClientController(IClientService clientService) => _clientService = clientService;

    [HttpGet]
    [Route("get-clients")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IEnumerable<ClientDto>> GetEntities() => await _clientService.GetEntities();
    
    [HttpGet]
    [Route("get-client/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<ClientDto> GetEntity(int id) => await _clientService.GetEntity(id);
    
    [HttpPost]
    [Route("send-client")]
    [Authorize(Roles = Role.Admin)]
    public void PostEntity(ClientDto dto) => _clientService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-client/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public void PostDelete(int id) => _clientService.PostDelete(id);
}