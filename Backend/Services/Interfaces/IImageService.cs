using Backend.Dto.Base;
using Core.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Interfaces;

public interface IImageService
{
    Task<IActionResult> GetImage(IEntityImage entityImage, string webRootPath);

    Task<string> SaveImage(IEntityImageDto dto, string webRootPath);
}