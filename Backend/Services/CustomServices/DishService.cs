using Backend.Dto.Dish;
using Backend.Services.Interfaces;
using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.UoF;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Backend.Services.CustomServices;

public class DishService : IDishService
{
    private readonly IUnitOfWork _unitOfWork;
    private IDishRepository _dishRepository => _unitOfWork.DishRepository;

    private readonly IImageService _imageService;
    
    private readonly IHostingEnvironment _webHostEnvironment;

    public DishService(IUnitOfWork unitOfWork, IHostingEnvironment webHostEnvironment, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
        _imageService = imageService;
    }

    public async Task<IEnumerable<DishDto>> GetEntities() => _dishRepository.GetEntities().Adapt<IEnumerable<DishDto>>();

    public async Task<DishDto> GetEntity(int id) => _dishRepository.GetDish(id).Adapt<DishDto>();

    public void PostEntity(DishDto dto)
    {
        var entity = dto?.Id != null && dto?.Id != 0
            ? _dishRepository.GetDish(dto.Id)
            : new Dish();

        entity.Name = dto.Name;
        entity.TaggingDish = dto.TaggingDish;
        entity.Type = dto.Type;
        entity.Price = dto.Price;
        
        _dishRepository.InsertOrUpdate(entity);
        _unitOfWork.Save();
    }

    public void PostDelete(int id)
    {
        _dishRepository.Remove(_dishRepository.GetDish(id));
        _unitOfWork.Save();
    }

    public async Task SaveImage(DishImageDto dto)
    {
        var dish = _dishRepository.GetDish(dto.Id);
        dish.ImagePath = await _imageService.SaveImage(dto, _webHostEnvironment.WebRootPath);
        _unitOfWork.Save();
    }

    public async Task<IActionResult> GetImage(int id)
    {
        var dish = _dishRepository.GetDish(id) ?? throw new ArgumentException("dish is null");

        return await _imageService.GetImage(dish, _webHostEnvironment.WebRootPath);
    }
}