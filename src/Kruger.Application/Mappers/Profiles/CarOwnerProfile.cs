using AutoMapper;
using Kruger.Application.Commands.CarOwnerCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;
using Kruger.Core.Enums;

namespace Kruger.Application.Mappers.Profiles
{
    public class CarOwnerProfile : Profile
    {
        public CarOwnerProfile()
        {
            CreateMap<CreateCarOwnerCommand, CarOwner>();
            CreateMap<UpdateCarOwnerCommand, CarOwner>();
            CreateMap<CarOwner, CarOwnerDto>()
                .ForMember(src => src.IdTypeDescription,
                    opts => opts.MapFrom(src => src.IdType.GetString()));
        }
    }
}
