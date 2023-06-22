using System;
using Core.Domain.Base;
using Core.Enums;

namespace Core.Domain;

public class DeliveryManVacation : EntityBase
{
    /// <summary>
    /// Начало отпуска
    /// </summary>
    public DateTime StartOfVacation { get; set; }
    
    /// <summary>
    /// Конец отпуска
    /// </summary>
    public DateTime EndOfVacation { get; set; }
    
    public int DeliveryManId { get; set; }
    public DeliveryMan DeliveryMan { get; set; }
    
    public TypeVacation TypeVacation { get; set; }
}