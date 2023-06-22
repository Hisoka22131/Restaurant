using System;
using System.Collections.Generic;
using Core.Domain.Base;

namespace Core.Domain;

public partial class Client : EntityBase
{
    public Client()
    {
        Orders = new HashSet<Order>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
    public string Adress { get; set; }
    public int? DiscountPercentage { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}