using System.Linq.Expressions;
using DatabaseAssignment.Contexts;
using DatabaseAssignment.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAssignment.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> RemoveAsync(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
        }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        var result = await _dbSet.AnyAsync(expression);
        return result;
    }
}
