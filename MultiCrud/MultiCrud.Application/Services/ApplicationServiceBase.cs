using AutoMapper;
using MultiCrud.Application.Abstractions.Services;
using MultiCrud.Domain.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiCrud.Application.Services
{
    public class ApplicationServiceBase<TEntity, TEntityInput, TEntityOutput> : IApplicationServiceBase<TEntity, TEntityInput, TEntityOutput>
        where TEntity : class
        where TEntityInput : class
        where TEntityOutput : class
    {
        private readonly IMapper _mapper;
        private readonly IDomainServiceBase<TEntity> _domainServiceBase;
        public ApplicationServiceBase(IMapper mapper, IDomainServiceBase<TEntity> domainServiceBase)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _domainServiceBase = domainServiceBase ?? throw new ArgumentNullException(nameof(domainServiceBase));
        }

        public async Task<IEnumerable<TEntityOutput>> GetAllAsync()
        {
            var collection = await _domainServiceBase.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<TEntityOutput>>(collection);
        }

        public async Task<TEntityOutput> GetByIdAsync(int key)
        {
            var entity = await _domainServiceBase.GetByIdAsync(key).ConfigureAwait(false);
            return _mapper.Map<TEntityOutput>(entity);
        }

        public async Task InsertAsync(TEntityInput entity)
        {
            var input = _mapper.Map<TEntity>(entity);
            await _domainServiceBase.InsertAsync(input).ConfigureAwait(false);
        }

        public async Task UpdateAsync(TEntityInput entity)
        {
            var input = _mapper.Map<TEntity>(entity);
            await _domainServiceBase.UpdateAsync(input).ConfigureAwait(false);
        }

        public async Task RemoveAsync(int key)
        {
            await _domainServiceBase.RemoveAsync(key).ConfigureAwait(false);
        }
    }
}
