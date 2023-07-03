namespace api.DTO;

public interface IBaseDto
{
    int Id { get; set; }
}

public abstract class BaseDto : IBaseDto
{
    public int Id { get; set; }
}