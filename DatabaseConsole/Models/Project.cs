namespace DatabaseConsole.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
    [Key]
    public string ProjectNumber { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public string ProjectManager { get; set; } = null!;

    [Required]
    public string Customer { get; set; } = null!;

    [Required]
    public string Service { get; set; } = null!;

    public decimal TotalPrice { get; set; }
    public ProjectStatus Status { get; set; }
}

public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed,
}
