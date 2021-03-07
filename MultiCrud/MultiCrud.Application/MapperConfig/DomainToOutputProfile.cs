using AutoMapper;
using MultiCrud.Application.InOut;
using MultiCrud.Domain.Entities;

namespace MultiCrud.Application.MapperConfig
{
    public class DomainToOutputProfile: Profile
    {
        public DomainToOutputProfile()
        {
            CreateMap<Person, PersonOutput>();
        }
    }
}
