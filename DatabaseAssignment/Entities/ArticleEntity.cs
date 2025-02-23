
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.Entities;

public class ArticleEntity
{
    [Key]
    public int Id { get; set; }
    public string EAN { get; set; }

    public string ArticleName { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal Price { get; set; }
    [Column(TypeName = "char(3)")]
    public string CurrencyId { get; set; } = null!;

    public virtual CurrencyEntity Currency { get; set; } = null!;

    public virtual ICollection<ProjectEntity> Projects { get; set; } = null!;
}
