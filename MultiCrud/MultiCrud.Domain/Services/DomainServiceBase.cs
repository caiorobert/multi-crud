using MultiCrud.Domain.Abstractions.Repositories;
using MultiCrud.Domain.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiCrud.Domain.Services
{
    public class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : class
    {
        private readonly IEntityRepositoryBase<TEntity> _baseRepository;
        public DomainServiceBase(IEntityRepositoryBase<TEntity> baseRepository)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> GetByIdAsync(int key)
        {
            return await _baseRepository.GetByIdAsync(key).ConfigureAwait(false);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _baseRepository.InsertAsync(entity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _baseRepository.UpdateAsync(entity).ConfigureAwait(false);
        }

        public async Task RemoveAsync(int key)
        {
            await _baseRepository.RemoveAsync(key).ConfigureAwait(false);
        }
    }
}
