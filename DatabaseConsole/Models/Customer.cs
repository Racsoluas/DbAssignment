namespace DatabaseConsole.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CompanyName { get; set; } = null!;

    [Required]
    public string ContactPerson { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }
}
