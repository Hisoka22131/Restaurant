using System.Collections.Generic;
using Backend.Dto.Order;
using Backend.Services.Interfaces;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService) => _orderService = orderService;

    [HttpGet]
    [Route("get-orders")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IEnumerable<OrderDto>> Get() => await _orderService.GetEntities();

    [HttpGet]
    [Route("get-my orders/{clientId:int}")]
    [Authorize(Roles = Role.DeliveryManOrClient)]
    public IEnumerable<OrderListDto> Get(int clientId) => _orderService.Get(clientId);

    [HttpPost]
    [Route("get-order/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<OrderDto> GetEntity(int id) => await _orderService.GetEntity(id);

    [HttpPost]
    [Route("post-order")]
    [Authorize(Roles = Role.DeliveryManOrClient)]
    public void PostOrder(OrderDto dto) => _orderService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-order")]
    [Authorize(Roles = Role.DeliveryManOrClient)]
    public void DeleteOrder(int id) => _orderService.PostDelete(id);
}