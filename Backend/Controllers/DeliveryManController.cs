using System.Collections.Generic;
using Backend.Dto.DeliveryMan;
using Backend.Services.Interfaces;
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
    [Route("get-delyverymans")]
    [AllowAnonymous]
    public IEnumerable<DeliveryManDto> Get() => _deliveryManService.GetEntities();

    [HttpPost]
    [Route("get-delyveryman")]
    public DeliveryManDto Get(int id) => _deliveryManService.GetEntity(id);

    [HttpPost]
    [Route("post-deliveryman")]
    public void PostDeliveryMan(DeliveryManDto dto) => _deliveryManService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-deliveryman")]
    public void DeleteDeliveryMan(int id) => _deliveryManService.PostDelete(id);
}