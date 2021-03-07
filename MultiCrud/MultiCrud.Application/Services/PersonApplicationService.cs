using AutoMapper;
using MultiCrud.Application.Abstractions.Services;
using MultiCrud.Application.InOut;
using MultiCrud.Domain.Abstractions.Services;
using MultiCrud.Domain.Entities;

namespace MultiCrud.Application.Services
{
    public sealed class PersonApplicationService : ApplicationServiceBase<Person, PersonInput, PersonOutput>, IPersonApplicationService
    {
        public PersonApplicationService(IMapper mapper, IDomainServiceBase<Person> domainServiceBase) : base(mapper, domainServiceBase)
        {
        }
    }
}
