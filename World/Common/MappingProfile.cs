using AutoMapper;
using World.DTO.Country;
using World.DTO.State;
using World.Models;

namespace World.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, DTO.Country.CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
            CreateMap<State, DTO.State.StateDTO>().ReverseMap();
            CreateMap<State, UpdateStateDTO>().ReverseMap();
            CreateMap<State, CreateStateDTO>().ReverseMap();
        }
    }
}
