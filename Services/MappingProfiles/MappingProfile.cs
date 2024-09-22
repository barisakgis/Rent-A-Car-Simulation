using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Car ve CarDetailDto arasında dönüşüm
            CreateMap<Car, CarDetailDto>()
                .ForMember(dest => dest.FuelName, opt => opt.MapFrom(src => src.Fuel.Name))
                .ForMember(dest => dest.TransmissionName, opt => opt.MapFrom(src => src.Transmission.Name))
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
                .ForMember(dest => dest.KiloMeter, opt => opt.MapFrom(src => src.KiloMeter))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.ModelYear))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.DailyPrice, opt => opt.MapFrom(src => src.DailyPrice))
                .ForMember(dest => dest.CarState, opt => opt.MapFrom(src => src.CarState));

            // CarDetailDto'dan Car'a dönüşüm
            CreateMap<CarDetailDto, Car>()
                .ForMember(dest => dest.FuelId, opt => opt.Ignore()) // FuelId manuel set edilebilir
                .ForMember(dest => dest.TransmissionId, opt => opt.Ignore()) // TransmissionId manuel set edilebilir
                .ForMember(dest => dest.ColorId, opt => opt.Ignore()); // ColorId manuel set edilebilir

            // Diğer DTO dönüşümleri
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Fuel, FuelDto>().ReverseMap();
            CreateMap<Transmission, TransmissionDto>().ReverseMap();
        }
    }
}

