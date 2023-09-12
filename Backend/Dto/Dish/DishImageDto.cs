using Backend.Dto.Base;

namespace Backend.Dto.Dish;

public class DishImageDto : EntityDto, IEntityImageDto
{
    public IFormFile File { get; set; }
}