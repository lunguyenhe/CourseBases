using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Domain.Abstraction;

public interface IRepositoryBase<TEntity, in TKey>
     where TEntity : class
{
    Task<TEntity> FindByIdAsync(
        TKey id,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProp);
    Task<TEntity> FindBySingleAsync(
    Expression<Func<TEntity, bool>>? predicate = null,
    CancellationToken cancellationToken = default,
    params Expression<Func<TEntity, object>>[] includeProp);


    IQueryable<TEntity> FindAll(
Expression<Func<TEntity, bool>>? predicate = null,
params Expression<Func<TEntity, object>>[] includeProp);

    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void RemoveMultiple(List<TEntity> entities);
}