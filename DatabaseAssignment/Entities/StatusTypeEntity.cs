
using System.ComponentModel.DataAnnotations;

namespace DatabaseAssignment.Entities;

public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

}
