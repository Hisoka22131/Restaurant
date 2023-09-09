namespace Core.Domain.Base;

public interface IEntityImage
{
    int Id { get; set; }
    string? ImagePath { get; set; }
}