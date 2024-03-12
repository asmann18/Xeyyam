namespace Xeyyam.Models;

public class Category:BaseEntity
{
    public string Name { get; set; } = null!;
}



public abstract class BaseEntity
{
    public int Id { get; set; }
}