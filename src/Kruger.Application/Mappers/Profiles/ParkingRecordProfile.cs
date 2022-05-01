using AutoMapper;
using Kruger.Application.Commands.ParkingRecordCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;

namespace Kruger.Application.Mappers.Profiles
{
    public class ParkingRecordProfile : Profile
    {
        public ParkingRecordProfile()
        {
            CreateMap<CreateParkingRecordCommand, ParkingRecord>();
            CreateMap<ParkingRecord, ParkingRecordDto>()
                .ForMember(dest => dest.CarOwnerFullName,
                    opts => opts.MapFrom(src => $"{src.CarOwner.Name} {src.CarOwner.LastName}"))
                .ForMember(dest => dest.ParkingPlaceDescription,
                    opts => opts.MapFrom(src => src.ParkingPlace.Description))
                .ForMember(dest => dest.CarPlate,
                    opts => opts.MapFrom(src => src.Car.Plate));
            CreateMap<ParkingRecord, FinishedParkingRecordDto>()
                .ForMember(dest => dest.CarOwnerFullName,
                    opts => opts.MapFrom(src => $"{src.CarOwner.Name} {src.CarOwner.LastName}"))
                .ForMember(dest => dest.ParkingPlaceDescription,
                    opts => opts.MapFrom(src => src.ParkingPlace.Description))
                .ForMember(dest => dest.CarPlate,
                    opts => opts.MapFrom(src => src.Car.Plate));
        }
    }
}
