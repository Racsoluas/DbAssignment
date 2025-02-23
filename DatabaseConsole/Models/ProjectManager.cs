namespace DatabaseConsole.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectManager
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    public string FullName => $"{FirstName} {LastName}";
}
