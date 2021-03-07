using AutoMapper;
using MultiCrud.Application.InOut;
using MultiCrud.Domain.Entities;

namespace MultiCrud.Application.MapperConfig
{
    public class InputToDomainProfile: Profile
    {
        public InputToDomainProfile()
        {
            CreateMap<PersonInput, Person>();
        }
    }
}
