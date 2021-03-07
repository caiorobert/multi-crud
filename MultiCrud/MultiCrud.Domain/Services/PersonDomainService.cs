using MultiCrud.Domain.Abstractions.Repositories;
using MultiCrud.Domain.Abstractions.Services;
using MultiCrud.Domain.Entities;

namespace MultiCrud.Domain.Services
{
    public sealed class PersonDomainService : DomainServiceBase<Person>, IPersonDomainService
    {
        public PersonDomainService(IEntityRepositoryBase<Person> baseRepository) : base(baseRepository)
        {
        }
    }
}
