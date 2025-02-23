using Buisness.Models;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Entities;

namespace Buisness.Factories;

public static class ActivityStatusFactory
{
    public static ActivityStatusEntity Create(ActivityStatusCreateForm form) => new()
    {
        Status = form.Status
    };

    public static ActivityStatusEntity Update(ActivityStatusUpdateForm form) => new()
    {
        Id = form.Id,
        Status = form.Status
    };

    public static ActivityStatus Create(ActivityStatusEntity entity) => new(entity.Id, entity.Status);
}
