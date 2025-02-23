using Buisness.Factories;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using Buisness.Models.Dtos;
using DatabaseAssignment.Interfaces;
using DatabaseAssignment.Repositories;

namespace Buisness.Services;

public class CustomerService(ICustomerRepositry customerRepositry)
{
    private readonly ICustomerRepositry _customerRepository = customerRepositry;

    public async Task<bool> CreateNewCustomerAsync(CustomerCreateForm form)
    {
        if (!await _customerRepository.ExistsAsync(x => x.CustomerName == form.CustomerName))
        {
            var entity = CustomerFactory.Create(form);
            entity = await _customerRepository.AddAsync(entity);
            return entity != null && entity.Id > 0;
        }
        return false;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var entities = await _customerRepository.GetAsync();
        return entities.Select(CustomerFactory.Create);
    }

    public async Task<Customer?> GetCustomerAsync(int id)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == id);
        return entity != null ? CustomerFactory.Create(entity) : null;
    }

    public async Task<bool> UpdateCustomerAsync(CustomerUpdateForm form)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == form.Id);

        if (entity != null)
        {
            entity = CustomerFactory.Update(form);
            entity = await _customerRepository.UpdateAsync(entity);
            return entity != null && entity.Id == form.Id;
        }
        return false;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == id);

        if (entity != null)
        {
            return await _customerRepository.RemoveAsync(entity);
        }
        return false;
    }
}
