using AutoMapper;
using World.DTO.Country;
using World.Models;

namespace World.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
        }
    }
}
