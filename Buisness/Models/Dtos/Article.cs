namespace Buisness.Models.Dtos;

public class Article
{
    public int Id { get; set; }
    public string? EAN { get; set; }
    public string ArticleName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public Currency Currency { get; set; } = null!;
}
