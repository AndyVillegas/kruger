using Kruger.Application.DTOs;
using MediatR;

namespace Kruger.Application.Queries.RateQueries
{
    public class GetRateByIdQuery : IRequest<RateDto>
    {
        public int Id { get; set; }
        public GetRateByIdQuery(int id)
        {
            Id = id;
        }
        public GetRateByIdQuery()
        { }
    }
}
