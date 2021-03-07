using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiCrud.Application.Abstractions.Services
{
    public interface IApplicationServiceBase<TEntity, TEntityInput, TEntityOutput>
        where TEntity : class
        where TEntityInput : class
        where TEntityOutput : class
    {
        Task<IEnumerable<TEntityOutput>> GetAllAsync();
        Task<TEntityOutput> GetByIdAsync(int key);
        Task InsertAsync(TEntityInput entity);
        Task UpdateAsync(TEntityInput entity);
        Task RemoveAsync(int key);
    }
}
