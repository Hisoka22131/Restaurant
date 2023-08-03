using System.Collections.Generic;
using Core.Domain.Base;
using Core.Enums;

namespace Core.Domain;

public partial class Dish : EntityBase
{
    public Dish()
    {
        DishesOrders = new HashSet<DishOrder>();
    }

    public string Name { get; set; }
    public string? Type { get; set; }
    public string? ImagePath { get; set; }
    public decimal Price { get; set; }
    public TaggingDish TaggingDish { get; set; }
    public virtual ICollection<DishOrder> DishesOrders { get; set; }
}