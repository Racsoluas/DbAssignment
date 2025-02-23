namespace Buisness.Models.Dtos.CreateForm;

public class ArticleCreateForm
{
    public string? EAN { get; set; }
    public string ArticleName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string CurrencyId { get; set; } = null!;
}
