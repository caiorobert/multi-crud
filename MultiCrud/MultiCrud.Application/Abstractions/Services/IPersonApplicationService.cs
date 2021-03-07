using MultiCrud.Application.InOut;
using MultiCrud.Domain.Entities;

namespace MultiCrud.Application.Abstractions.Services
{
    public interface IPersonApplicationService : IApplicationServiceBase<Person, PersonInput, PersonOutput>
    {
    }
}
