﻿using System.Linq.Expressions;

namespace DatabaseAssignment.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> RemoveAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity entity);
}
