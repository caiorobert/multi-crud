using Microsoft.EntityFrameworkCore;
using MultiCrud.Domain.Abstractions.Repositories;
using MultiCrud.Infrastructure.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiCrud.Infrastructure.Repository.Repositories
{
    public class EntityRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity> where TEntity : class
    {
        private readonly MultiCrudContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public EntityRepositoryBase(MultiCrudContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync
        (
            int skip,
            int take,
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>> orderBy
        )
        {
            return await _dbSet
                .OrderBy(orderBy)
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int skip, int take)
        {
            return await _dbSet
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TEntity> GetByIdAsync(int key)
        {
            return await _dbSet
                .FindAsync(key)
                .ConfigureAwait(false);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context
                .AddAsync(entity)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RemoveAsync(int key)
        {
            var entityToRemove = _dbSet.Find(key);
            _context.Remove(entityToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
