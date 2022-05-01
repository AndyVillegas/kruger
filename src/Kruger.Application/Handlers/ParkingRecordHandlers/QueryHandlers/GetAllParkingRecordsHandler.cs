using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Pagination;
using Kruger.Application.DTOs;
using Kruger.Application.Queries.ParkingRecordQueries;
using Kruger.Core.Interfaces.Repositories;
using MediatR;

namespace Kruger.Application.Handlers.ParkingRecordHandlers.QueryHandlers
{
    public class GetAllParkingRecordsHandler : IRequestHandler<GetAllParkingRecordsQuery, PaginatedResponse<ParkingRecordDto>>
    {
        private readonly IParkingRecordRepository _repository;
        private readonly IMapper _mapper;

        public GetAllParkingRecordsHandler(
            IParkingRecordRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<ParkingRecordDto>> Handle(GetAllParkingRecordsQuery request, CancellationToken cancellationToken)
        {
            var parkingRecords = await _repository.GetAll(request.Search, request);
            return _mapper.Map<PaginatedResponse<ParkingRecordDto>>(parkingRecords);
        }
    }
}
