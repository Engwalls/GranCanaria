using AutoMapper;
using GranCanariaAPI.Models;
using GranCanariaAPI.Models.DTO;

namespace GranCanariaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Apartment, ApartmentDto>();
            CreateMap<ApartmentDto, Apartment>();

            // Gör samma sak som koden ovan, mindre kod bara.
            CreateMap<Apartment, ApartmentCreateDto>().ReverseMap();
            CreateMap<Apartment, ApartmentUpdateDto>().ReverseMap();
        }
    }
}
