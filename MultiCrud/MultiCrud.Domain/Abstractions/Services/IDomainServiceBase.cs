using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiCrud.Domain.Abstractions.Services
{
    public interface IDomainServiceBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int key);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int key);
    }
}
