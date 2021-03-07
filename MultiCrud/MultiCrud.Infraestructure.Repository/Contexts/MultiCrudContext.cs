using Microsoft.EntityFrameworkCore;
using MultiCrud.Domain.Entities;

namespace MultiCrud.Infrastructure.Repository.Contexts
{
    public class MultiCrudContext: DbContext
    {
        public MultiCrudContext(DbContextOptions<MultiCrudContext> options) : base(options)
        { 
        }

        public DbSet<Person> Persons { get; set; }
    }
}
