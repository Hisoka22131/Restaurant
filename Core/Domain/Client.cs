using System;
using System.Collections.Generic;
using Core.Domain.Base;

namespace Core.Domain;

public partial class Client : PersonalInfoBase
{
    public Client()
    {
        Orders = new HashSet<Order>();
    }
    
    public int? DiscountPercentage { get; set; }

    public virtual ICollection<Order> Orders { get; set; } 
}