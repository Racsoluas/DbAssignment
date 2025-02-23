using Buisness.Models.Dtos;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Entities;

namespace Buisness.Factories;

public static class ProjectFactory
{
    public static ProjectEntity Create(ProjectCreateForm form) => new()
    {
       ProjectName = form.ProjectName,
        Notes = form.Notes,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        ProjectManagerId = form.ProjectManagerId,
        StatusId = form.StatusId,
        CustomerId = form.CustomerId,
        ArticleId = form.ArticleId,
    };

    public static ProjectEntity Update(ProjectUpdateForm form) => new()
    {
        Id = form.Id,
        ProjectName = form.ProjectName,
        Notes = form.Notes,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        ProjectManagerId = form.ProjectManagerId,
        StatusId = form.StatusId,
        CustomerId = form.CustomerId,
        ArticleId = form.ArticleId,
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        Notes = entity.Notes,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        ProjectManager = UserFactory.Create(entity.ProjectManager),
        Status = ActivityStatusFactory.Create(entity.Status),
        Customer = CustomerFactory.Create(entity.Customer),
        Article = ArticleFactory.Create(entity.Article),
        
    };
}
