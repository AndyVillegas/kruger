using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.CarQueries
{
    public class GetCarByIdQuery : IRequest<CarDto>
    {
        public int Id { get; set; }
        public GetCarByIdQuery(int id)
        {
            Id = id;
        }
        public GetCarByIdQuery()
        { }
    }
}
