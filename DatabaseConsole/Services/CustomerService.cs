using System.Net.Http.Json;
using DatabaseConsole.Data;
using DatabaseConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConsole.Services;

public class CustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomers() => 
        await _context.Customers.ToListAsync();

    public async Task<Customer?> GetCustomer(int id) => 
        await _context.Customers.FindAsync(id);

    public async Task<bool> CreateCustomer(Customer customer)
    {
        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateCustomer(int id, Customer customer)
    {
        try
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
