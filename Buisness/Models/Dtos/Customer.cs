namespace Buisness.Models.Dtos;

public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public IEnumerable<Project> Projects { get; set; } = [];
    public string? Email { get; set; } = null!;

}