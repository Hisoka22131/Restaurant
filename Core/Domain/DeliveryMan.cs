using System.Collections.Generic;
using Core.Domain.Base;

namespace Core.Domain;

public partial class DeliveryMan : EntityBase
{
    public DeliveryMan()
    {
        Orders = new HashSet<Order>();
        DeliveryManVacations = new HashSet<DeliveryManVacation>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] PassportSeries { get; set; }
    public int DistrictId { get; set; }
    public string City { get; set; }
    public virtual District District { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<DeliveryManVacation> DeliveryManVacations { get; set; }
}