using Cousera.Domain.Abstraction;
using Cousera.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Infrastructure.Repositories;

public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>, IDisposable
where TEntity : EntityBase<TKey>
{
    public readonly ApplicationDBContext _dbContext;


    public RepositoryBase(ApplicationDBContext dbContext)
        => _dbContext = dbContext;


    public void Dispose()
    {
        _dbContext?.Dispose();
    }
    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> items = _dbContext.Set<TEntity>().AsNoTracking();

        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties)
            {
                items = items.Include(includeProperty);
            }

        }
        if (predicate is not null)
        {
            items = items.Where(predicate);
        }
        return items;


    }

    public void Add(TEntity entity) => _dbContext.Add(entity);




    public async Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProp)
    {
        return await FindAll(null, includeProp).AsTracking()
             .SingleOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
    }

    public async Task<TEntity> FindBySingleAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProp)
    {
        return await FindAll(null, includeProp).AsTracking()
            .SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public void Remove(TEntity entity)
    => _dbContext.Set<TEntity>().Remove(entity);


    public void RemoveMultiple(List<TEntity> entities)
    => _dbContext.Set<TEntity>().RemoveRange(entities);

    public void Update(TEntity entity)
    => _dbContext.Set<TEntity>().Update(entity);
}
