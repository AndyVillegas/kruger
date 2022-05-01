using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.CarOwnerQueries
{
    public class GetCarOwnerByIdQuery : IRequest<CarOwnerDto>
    {
        public int Id { get; set; }
        public GetCarOwnerByIdQuery(int id)
        {
            Id = id;
        }
        public GetCarOwnerByIdQuery()
        { }
    }
}
