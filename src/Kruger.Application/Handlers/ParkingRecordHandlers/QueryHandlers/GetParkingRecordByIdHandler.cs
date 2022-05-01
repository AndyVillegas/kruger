using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Application.Queries.ParkingRecordQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.ParkingRecordHandlers.QueryHandlers
{
    public class GetParkingRecordByIdHandler : IRequestHandler<GetParkingRecordByIdQuery, ParkingRecordDto>
    {
        private readonly IParkingRecordRepository _repository;
        private readonly IMapper _mapper;

        public GetParkingRecordByIdHandler(
            IParkingRecordRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ParkingRecordDto> Handle(GetParkingRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var parkingRecords = await _repository.GetOne(request.Id);
            if (parkingRecords == null)
                throw new ParkingRecordNotFoundException();
            return _mapper.Map<ParkingRecordDto>(parkingRecords);
        }
    }
}
