using DatabaseAssignment.Contexts;
using DatabaseAssignment.Entities;
using DatabaseAssignment.Interfaces;

namespace DatabaseAssignment.Repositories;

internal class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context), IProductRepository
{
    private readonly DataContext _context = context;
}
