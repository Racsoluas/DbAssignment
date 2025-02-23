using DatabaseAssignment.Contexts;
using DatabaseAssignment.Entities;
using DatabaseAssignment.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAssignment.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepositry
{
    private readonly DataContext _context = context;
    
    // Create - Lägger till en ny kund
    public async Task<CustomerEntity> CreateAsync(CustomerEntity customer)
    {
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<CustomerEntity> entityEntry = _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    // Read - Hämtar en kund baserat på id
    public async Task<CustomerEntity?> GetByIdAsync(int id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }
    
    // Read - Hämtar alla kunder
    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    // Update - Uppdaterar en befintlig kund
    public async Task<bool> UpdateAsync(CustomerEntity customer)
    {
        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
        if (existingCustomer == null)
        {
            return false;
        }
        // Uppdaterar kundens värden
        _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
        await _context.SaveChangesAsync();
        return true;
    }
    
    // Delete - Tar bort en kund baserat på id samt ändrade kontroll av en kund som inte är null först.
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
