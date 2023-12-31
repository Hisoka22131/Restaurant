using System;
using System.Collections.Generic;
using Core.Domain.Base;

namespace Core.Domain;

public partial class Client : PersonalInfoBase, IEntityImage
{
    public Client()
    {
        Orders = new HashSet<Order>();
    }

    public string? ImagePath { get; set; }
    public int? DiscountPercentage { get; set; }
    public virtual ICollection<Order> Orders { get; set; } 
}