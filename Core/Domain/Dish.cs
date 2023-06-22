using System.Collections.Generic;
using Core.Domain.Base;
using Core.Enums;

namespace Core.Domain;

public partial class Dish : EntityBase
{
    public Dish()
    {
        DishesOrders = new HashSet<DishesOrder>();
    }

    public string Name { get; set; }
    public string? Type { get; set; }
    public string? ImagePath { get; set; }
        
    public TaggingDish TaggingDish { get; set; }

    public virtual ICollection<DishesOrder> DishesOrders { get; set; }
}