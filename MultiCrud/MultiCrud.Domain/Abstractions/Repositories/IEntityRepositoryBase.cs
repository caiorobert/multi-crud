using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiCrud.Domain.Abstractions.Repositories
{
    public interface IEntityRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync
        (
            int skip,
            int take,
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>> orderBy
        );

        Task<IEnumerable<TEntity>> GetAllAsync(int skip, int take);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int key);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int key);
    }
}
