using Backend.Dto.Base;
using Backend.Services.Interfaces;
using Core.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.CustomServices;

public class ImageService : IImageService
{
    public async Task<IActionResult> GetImage(IEntityImage entityImage, string webRootPath)
    {
        var imagePath = Path.Combine(webRootPath, !string.IsNullOrEmpty(entityImage.ImagePath) && entityImage.Id != 0 ? entityImage.ImagePath : "images/error.jpg");
        var imageBytes = await File.ReadAllBytesAsync(imagePath);
        return new FileContentResult(imageBytes, "image/jpeg");
    }

    public async Task<string> SaveImage(IEntityImageDto dto, string webRootPath)
    {
        var imagePath = Path.Combine(webRootPath, "images");
        
        if (!Directory.Exists(imagePath))
        {
            Directory.CreateDirectory(imagePath);
        }
        
        var fileName = Path.GetFileName(dto.File.FileName);
        var filePath = Path.Combine(imagePath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await dto.File.CopyToAsync(stream);
        return Path.Combine("images", fileName);
    }
}