
using System.ComponentModel.DataAnnotations;

namespace DatabaseAssignment.Entities;

public class CustomerEntity
    {
    [Key]
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;

    public virtual ICollection<ProjectEntity> Projects { get; set; } = null!;

}
