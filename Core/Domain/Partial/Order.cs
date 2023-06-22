using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Core.Domain;

public partial class Order
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Number))
        {
            yield return new ValidationResult("Number is null");
        }

        if (DiscountAmount < 0)
        {
            yield return new ValidationResult("DiscountAmount < 0");
        }

        if (Price < 0)
        {
            yield return new ValidationResult("Price < 0");
        }
    }
    
    public void AddDishInOrder(IEnumerable<Dish> dishes)
    {
        foreach (var dish in dishes)
        {
            var dishesOrder = DishesOrders.FirstOrDefault(q => q.DishesId == dish.Id);
            if (dishesOrder != null)
                dishesOrder.Count++;
            else
                DishesOrders.Add(new DishesOrder()
                {
                    Dishes = dish,
                    Order = this,
                    Count = dishes.Count(q => q.Id == dish.Id)
                });
        }
    }
}