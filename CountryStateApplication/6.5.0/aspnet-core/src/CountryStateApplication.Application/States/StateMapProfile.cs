using AutoMapper;
using CountryStateApplication.States.Dto;

namespace CountryStateApplication.States
{
    public class StateMapProfile: Profile
    {
        public StateMapProfile()
        {
            CreateMap<StateDto, State>().ReverseMap();

            CreateMap<CreateStateDto, State>().ReverseMap();
        }
    }
}