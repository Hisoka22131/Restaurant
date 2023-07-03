using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Base;
using Core.Enums;

namespace Core.Domain;

public partial class Order : EntityBase, IValidatableObject
{
    public Order()
    {
        DishesOrders = new HashSet<DishesOrder>();
    }

    public string Number { get; set; }
    public TypeOrder Type { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountAmount { get; set; }
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }
    public int DeliveryManId { get; set; }
    public virtual DeliveryMan DeliveryMan { get; set; }
    public virtual ICollection<DishesOrder> DishesOrders { get; set; }
}