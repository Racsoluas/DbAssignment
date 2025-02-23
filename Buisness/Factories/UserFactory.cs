using Buisness.Models.Dtos;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Entities;

namespace Buisness.Factories;

public static class UserFactory
{
    public static UserEntity Create(UserCreateForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
    };

    public static UserEntity Update(UserUpdateForm form) => new()
    {
        Id = form.Id,
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
    };

    public static User Create(UserEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        Projects = entity.Projects.Select(ProjectFactory.Create).ToList()
    };
}
