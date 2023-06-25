using Backend.Dto.Dish;
using Backend.Services.Base;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Interfaces;

public interface IDishService : IBaseService<Dish, DishDto>
{
    void SaveImage(IFormFile imageFile, int id);
    IActionResult GetImage(int id);
}