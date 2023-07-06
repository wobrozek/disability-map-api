using AutoMapper;
using disability_map.Dtos;
using disability_map.Models;

namespace disability_map
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Place, PostPlaceDto>().ReverseMap();
            //CreateMap<Place, GetPlaceDto>().ForMember(dest => dest.LL, opt => opt.MapFrom(src => src.Cords)).ReverseMap();
            CreateMap<Place, CordsDto>().ReverseMap();
            CreateMap<Cords, CordsDto>().ReverseMap();
            CreateMap<Place, GetPlaceDto>().ForMember(dest => dest.LL, opt => opt.MapFrom(src => src.Cords)).ReverseMap();

        }
    }
}
