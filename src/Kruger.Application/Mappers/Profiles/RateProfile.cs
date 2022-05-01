using AutoMapper;
using Kruger.Application.Commands.RateCommands;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;

namespace Kruger.Application.Mappers.Profiles
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateMap<CreateRateCommand, Rate>();
            CreateMap<UpdateRateCommand, Rate>();
            CreateMap<Rate, RateDto>();
        }
    }
}
