using System.ComponentModel;

namespace Core.Enums;

/// <summary>
/// Пометка блюда
/// </summary>
public enum TaggingDish : byte
{
    [Description("Неизвестно")]
    None,
    
    [Description("Стоп-лиcт")]
    StopList,
    
    [Description("Горячее предложение")]
    HotOffer
}