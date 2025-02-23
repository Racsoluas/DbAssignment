
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;

    public string? Notes { get; set; } = null!;


    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    public int ProjectManagerId { get; set; }
    public virtual UserEntity ProjectManager { get; set; } = null!;
    public int StatusId { get; set; }
    public virtual ActivityStatusEntity Status { get; set; } = null!; 
    
    public int CustomerId { get; set; }
    public virtual CustomerEntity Customer { get; set; } = null!;

    public int ArticleId { get; set; }
    public virtual ArticleEntity Article { get; set; } = null!;


}