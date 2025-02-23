using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAssignment.Entities;

    public class UserEntity
    {
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; } = null!;

    public virtual ICollection<ProjectEntity> Projects { get; set; } = null!;
}


