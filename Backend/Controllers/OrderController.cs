using System.Collections.Generic;
using Backend.Dto.Order;
using Backend.Services.Interfaces;
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
    public IEnumerable<OrderDto> Get() => _orderService.GetEntities();

    [HttpPost]
    [Route("get-order/{id:int}")]
    public OrderDto GetEntity(int id) => _orderService.GetEntity(id);

    [HttpPost]
    [Route("post-order")]
    public void PostOrder(OrderDto dto) => _orderService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-order")]
    public void DeleteOrder(int id) => _orderService.PostDelete(id);
}