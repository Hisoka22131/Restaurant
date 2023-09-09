namespace Backend.Dto.Base;

public interface IEntityImageDto
{
    public int Id { get; set; }
    public IFormFile File { get; set; }
}