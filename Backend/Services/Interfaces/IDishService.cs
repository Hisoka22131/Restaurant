using Backend.Dto.Dish;
using Backend.Services.Base;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Interfaces;

public interface IDishService : IBaseService<Dish, DishDto>
{
    Task SaveImage(DishImageDto dto); 
    Task<IActionResult> GetImage(int id);
}