using System.Collections.Generic;
using Backend.Dto.Dish;
using Backend.Services.Interfaces;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DishController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService) => _dishService = dishService;

    [HttpGet]
    [Route("get-dishes")]
    [AllowAnonymous]
    public async Task<IEnumerable<DishDto>> Get() => await _dishService.GetEntities();

    [HttpPost]
    [Route("get-dish/{id:int}")]
    public async Task<DishDto> Get(int id) => await _dishService.GetEntity(id);

    [HttpPost]
    [Route("post-dish")]
    [Authorize(Roles = Role.Admin)]
    public void PostDish(DishDto dto) => _dishService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-dish")]
    [Authorize(Roles = Role.Admin)]
    public void DeleteDish(int id) => _dishService.PostDelete(id);

    [HttpPost]
    [Route("save-dish-image")]
    [Authorize(Roles = Role.Admin)]
    public void SaveImage(IFormFile imageFile, int id) => _dishService.SaveImage(imageFile, id);
    
    [HttpGet]
    [Route("get-dish-image/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> GetImage(int id) => await _dishService.GetImage(id);
}