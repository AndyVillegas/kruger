using AutoMapper;
using Kruger.Application.Commands.ParkingPlaceCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;

namespace Kruger.Application.Mappers.Profiles
{
    public class ParkingPlaceProfile : Profile
    {
        public ParkingPlaceProfile()
        {
            CreateMap<CreateParkingPlaceCommand, ParkingPlace>();
            CreateMap<UpdateParkingPlaceCommand, ParkingPlace>();
            CreateMap<ParkingPlace, ParkingPlaceDto>()
                .ForMember(src => src.RateDescription,
                    opts => opts.MapFrom(src => src.Rate.Description))
                .ForMember(src => src.RateHourlyCost,
                    opts => opts.MapFrom(src => src.Rate.HourlyCost));
        }
    }
}
