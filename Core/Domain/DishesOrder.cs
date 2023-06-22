using Core.Domain.Base;

namespace Core.Domain;

public partial class DishesOrder : EntityBase
{
    public int DishesId { get; set; }
    public int OrderId { get; set; }
    public int Count { get; set; }
    public virtual Dish Dishes { get; set; }
    public virtual Order Order { get; set; }
}