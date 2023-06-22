using System.ComponentModel;

namespace Core.Enums;

public enum TypeVacation : byte
{
    None,
    
    [Description("Оплачиваемый ежегодный")]
    Paid,
    
    [Description("Дополнительный оплачиваемый")]
    AdditionalPaid,
    
    [Description("Без сохранения заработной платы")]
    WithoutPaycheck
}