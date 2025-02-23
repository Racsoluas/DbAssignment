
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.Entities;

public class CurrencyEntity
{
    [Key]
    [Column(TypeName = "char(3)")]

    public string CurrencyCode { get; set; } = null!;
    public string Currency { get; set; } = null!;

    [Column(TypeName = "char(3)")]
    public string CurrencySymbol { get; set; } = null!;
    public decimal Price { get; set; }
    public virtual ICollection<ArticleEntity> Articles { get; set; } = [];
}
