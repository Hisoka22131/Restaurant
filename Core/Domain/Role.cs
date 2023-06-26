using Core.Domain.Base;

namespace Core.Domain;

public partial class Role : EntityBase
{
    public string Name { get; set; }
}