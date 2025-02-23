namespace Buisness.Models.Dtos.CreateForm;

public class ProjectCreateForm
{
    public string ProjectName { get; set; } = null!;
    public string? Notes { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ProjectManagerId { get; set; }
    public int StatusId { get; set; }
    public int CustomerId { get; set; }
    public int ArticleId { get; set; }
}
