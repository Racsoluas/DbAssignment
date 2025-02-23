namespace Buisness.Models.Dtos;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Notes { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public User ProjectManager { get; set; } = null!;
    public ActivityStatus Status { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public Article Article { get; set; } = null!;

}
