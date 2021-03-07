using Microsoft.EntityFrameworkCore;
using MultiCrud.Domain.Abstractions.Repositories;
using MultiCrud.Domain.Entities;

namespace MultiCrud.Infrastructure.Repository.Repositories
{
    public sealed class PersonEntityRepository : EntityRepositoryBase<Person>, IPersonEntityRepository
    {
        public PersonEntityRepository(DbSet<Person> entityDbSet) : base(entityDbSet)
        {
        }
    }
}
