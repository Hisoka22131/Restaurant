using System.Collections.Generic;
using Core.Domain.Base;

namespace Core.Domain;

public partial class DeliveryMan : PersonalInfoBase
{
    public DeliveryMan()
    {
        Orders = new HashSet<Order>();
        DeliveryManVacations = new HashSet<DeliveryManVacation>();
    }

    public int DistrictId { get; set; }
    public virtual District District { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<DeliveryManVacation> DeliveryManVacations { get; set; }
}