using AutoMapper;
using Kruger.Application.Commands.CarCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;

namespace Kruger.Application.Mappers.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarCommand, Car>();
            CreateMap<UpdateCarCommand, Car>();
            CreateMap<Car, CarDto>();
        }
    }
}
