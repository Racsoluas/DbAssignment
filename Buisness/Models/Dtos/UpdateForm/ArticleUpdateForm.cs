using Buisness.Models.Dtos.CreateForm;

namespace Buisness.Models.Dtos.UpdateForm;

public class ArticleUpdateForm : ArticleCreateForm
{
    public int Id { get; set; }
}
