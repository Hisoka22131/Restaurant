﻿using System.Collections.Generic;
using Backend.Dto.DishOrder;
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
    [Route("get-my-orders/{clientId:int}")]
    [Authorize(Roles = Role.Client)]
    public async Task<IEnumerable<OrderListDto>> Get(int clientId) => await _orderService.Get(clientId);
    
    [HttpGet]
    [Route("get-all-orders/{userId:int}")]
    [Authorize(Roles = Role.Client)]
    public async Task<IEnumerable<OrderListDto>> GetForAdmin(int userId) => await _orderService.Get(userId);

    [HttpGet]
    [Route("get-order/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<OrderDto> GetEntity(int id) => await _orderService.GetEntity(id);

    [HttpPost]
    [Route("post-order")]
    [Authorize(Roles = Role.Client)]
    public void PostOrder(OrderDto dto) => _orderService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-order")]
    [Authorize(Roles = Role.Client)]
    public void DeleteOrder(int id) => _orderService.PostDelete(id);

    [HttpPost]
    [Route("create-order")]
    [Authorize(Roles = Role.Client)]
    public void CreateOrder(IEnumerable<CreateDishOrderDto> dishOrderDtos) => _orderService.CreateOrder(dishOrderDtos);

}