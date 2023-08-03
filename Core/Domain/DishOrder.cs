using Core.Domain.Base;

namespace Core.Domain;

public partial class DishOrder : EntityBase
{
    public int DishId { get; set; }
    public int OrderId { get; set; }
    public int Count { get; set; }
    public virtual Dish Dish { get; set; }
    public virtual Order Order { get; set; }
}