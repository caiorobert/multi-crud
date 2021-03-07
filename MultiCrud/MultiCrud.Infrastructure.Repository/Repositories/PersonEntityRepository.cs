using Microsoft.EntityFrameworkCore;
using MultiCrud.Domain.Abstractions.Repositories;
using MultiCrud.Domain.Entities;
using MultiCrud.Infrastructure.Repository.Contexts;

namespace MultiCrud.Infrastructure.Repository.Repositories
{
    public sealed class PersonEntityRepository : EntityRepositoryBase<Person>, IPersonEntityRepository
    {
        public PersonEntityRepository(MultiCrudContext context) : base(context)
        {
        }
    }
}
