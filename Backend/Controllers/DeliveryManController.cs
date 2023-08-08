using System.Collections.Generic;
using Backend.Dto.DeliveryMan;
using Backend.Services.Interfaces;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DeliveryManController : ControllerBase
{
    private readonly IDeliveryManService _deliveryManService;

    public DeliveryManController(IDeliveryManService deliveryManService) => _deliveryManService = deliveryManService;

    [HttpGet]
    [Route("get-delivery-mans")]
    [Authorize(Roles = Role.DeliveryManOrAdmin)]
    public async Task<IEnumerable<DeliveryManDto>> Get() => await _deliveryManService.GetEntities();

    [HttpGet]
    [Route("get-delivery-man/{id:int}")]
    [Authorize(Roles = Role.DeliveryManOrAdmin)]
    public async Task<DeliveryManDto> Get(int id) => await _deliveryManService.GetEntity(id);

    [HttpPost]
    [Route("send-delivery-man")]
    [Authorize(Roles = Role.Admin)]
    public void PostDeliveryMan(DeliveryManDto dto) => _deliveryManService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-delivery-man/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public void DeleteDeliveryMan(int id) => _deliveryManService.PostDelete(id);
    
    [HttpPost]
    [Route("create-delivery-man")]
    [Authorize(Roles = Role.Admin)]
    public void CreateDeliveryMan(CreateDeliveryManDto dto) => _deliveryManService.CreateDeliveryMan(dto);
}