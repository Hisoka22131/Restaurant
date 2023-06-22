using System.Collections.Generic;
using Core.Domain.Base;

namespace Core.Domain;

public partial class District : EntityBase
{
    public District()
    {
        DeliveryMens = new HashSet<DeliveryMan>();
    }

    public string Name { get; set; }

    public virtual ICollection<DeliveryMan> DeliveryMens { get; set; }
}