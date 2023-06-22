using Backend.Dto.Base;
using Core.Enums;

namespace Backend.Dto.Dish;

public class DishDto : EntityDto
{
    public string Name { get; set; }
    
    public string Type { get; set; }
        
    public TaggingDish TaggingDish { get; set; }
}