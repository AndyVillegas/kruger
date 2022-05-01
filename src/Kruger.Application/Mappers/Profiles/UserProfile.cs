using AutoMapper;
using Kruger.Application.DTOs;
using Kruger.Core.Entities;

namespace Kruger.Application.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
