using System;
using System.Collections.Generic;
using System.IO;
using Backend.Dto.Dish;
using Backend.Helpers;
using Backend.Services.Base;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.CustomServices;

public class DishService : IDishService
{
    private readonly IUnitOfWork _unitOfWork;
    private IDishRepository _dishRepository => _unitOfWork.DishRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private IDishService _dishServiceImplementation;

    public DishService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IEnumerable<DishDto> GetEntities() => _dishRepository.GetEntities().Adapt<IEnumerable<DishDto>>();

    public DishDto GetEntity(int id) => _dishRepository.GetDish(id).Adapt<DishDto>();

    public void PostEntity(DishDto dto)
    {
        var entity = dto?.Id != null
            ? _dishRepository.GetDish(dto.Id)
            : new Dish();

        entity.Name = dto.Name;
        entity.TaggingDish = dto.TaggingDish;
        entity.Type = dto.Type;
        _dishRepository.InsertOrUpdate(entity);
        _unitOfWork.Save();
    }

    public void PostDelete(int id)
    {
        _dishRepository.Remove(_dishRepository.GetDish(id));
        _unitOfWork.Save();
    }

    public void SaveImage(IFormFile imageFile, int id)
    {
        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        
        if (!Directory.Exists(imagePath))
        {
            Directory.CreateDirectory(imagePath);
        }
        
        var fileName = Path.GetFileName(imageFile.FileName);
        var filePath = Path.Combine(imagePath, fileName);
        
        using var stream = new FileStream(filePath, FileMode.Create);
        imageFile.CopyTo(stream);
        var relativeImagePath = Path.Combine("images", fileName);
        var dish = _dishRepository.GetDish(id);
        dish.ImagePath = relativeImagePath;
        _unitOfWork.Save();
    }

    public IActionResult GetImage(int id)
    {
        var dish = _dishRepository.GetDish(id);
        if (dish == null) throw new ArgumentException(nameof(dish));
        
        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, dish.ImagePath);
        var imageBytes = File.ReadAllBytes(imagePath);
        return new FileContentResult(imageBytes, "image/jpeg"); // Измените тип контента в зависимости от типа изображения
    }
}