using Buisness.Models.Dtos;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Entities;

namespace Buisness.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create(CustomerCreateForm form) => new()
    {
        CustomerName = form.CustomerName,
    };

    public static CustomerEntity Update(CustomerUpdateForm form) => new()
    {
        Id = form.Id,
        CustomerName = form.CustomerName,
    };

    public static Customer Create(CustomerEntity entity) => new()
    {     
        Id = entity.Id,
        CustomerName = entity.CustomerName,
        Projects = entity.Projects.Select(ProjectFactory.Create).ToList()
    };
}
