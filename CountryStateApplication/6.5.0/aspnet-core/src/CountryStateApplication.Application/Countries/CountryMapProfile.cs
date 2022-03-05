using AutoMapper;
using CountryStateApplication.Countries.Dto;

namespace CountryStateApplication.Countries
{
    class CountryMapProfile : Profile
    {
        public CountryMapProfile()
        {
            CreateMap<CountryDto, Country>().ReverseMap();

            CreateMap<CreateCountryDto, Country>().ReverseMap();
        }
    }
}
