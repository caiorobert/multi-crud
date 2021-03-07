using Microsoft.EntityFrameworkCore;
using MultiCrud.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiCrud.Infrastructure.Repository.Repositories
{
    public abstract class EntityRepositoryBase<TEntity>: IEntityRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entityDbSet;
        public EntityRepositoryBase(DbSet<TEntity> entityDbSet)
        {
            _entityDbSet = entityDbSet ?? throw new ArgumentNullException(nameof(entityDbSet));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync
        (
            int skip,
            int take,
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>> orderBy
        )
        {
            return await _entityDbSet
                .AsNoTracking()
                .OrderBy(orderBy)
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int skip,int take)
        {
            return await _entityDbSet
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entityDbSet
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TEntity> GetByIdAsync(int key)
        {
            return await _entityDbSet.FindAsync(key).ConfigureAwait(false);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _entityDbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _entityDbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(int key)
        {
            var entityToRemove = _entityDbSet.Find(key);
            _entityDbSet.Remove(entityToRemove);
            return Task.CompletedTask;
        }
    }
}
