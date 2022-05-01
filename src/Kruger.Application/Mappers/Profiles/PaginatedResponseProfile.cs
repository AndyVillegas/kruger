using AutoMapper;
using Common.Pagination;

namespace Kruger.Application.Mappers.Profiles
{
    public class PaginatedResponseProfile : Profile
    {
        public PaginatedResponseProfile()
        {
            CreateMap(typeof(PaginatedResponse<>), typeof(PaginatedResponse<>));
        }
    }
}
