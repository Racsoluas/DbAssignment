using Buisness.Models.Dtos.CreateForm;

namespace Buisness.Models.Dtos.UpdateForm;

public class ProjectUpdateForm : ProjectCreateForm
{
    public int Id { get; set; }
}