using AutoMapper;
using Common.Helpers.Interfaces;
using Kruger.Application.Commands.ParkingRecordCommands;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kruger.Application.Handlers.ParkingRecordHandlers.CommandHandlers
{
    public class FinishParkingRecordHandler : IRequestHandler<FinishParkingRecordCommand, FinishedParkingRecordDto>
    {
        private readonly IParkingRecordRepository _repository;
        private readonly IParkingPlaceRepository _placeRepository;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IMapper _mapper;

        public FinishParkingRecordHandler(
            IParkingRecordRepository repository,
            IParkingPlaceRepository placeRepository,
            IDateTimeHelper dateTimeHelper,
            IMapper mapper)
        {
            _repository = repository;
            _placeRepository = placeRepository;
            _dateTimeHelper = dateTimeHelper;
            _mapper = mapper;
        }

        public async Task<FinishedParkingRecordDto> Handle(FinishParkingRecordCommand request, CancellationToken cancellationToken)
        {
            var parkingRecord = await _repository.GetOne(request.Id);
            if (parkingRecord == null)
                throw new ParkingRecordNotFoundException();
            if (parkingRecord.EndTime.HasValue)
                throw new EndedParkingRecordException();
            parkingRecord.EndTime = _dateTimeHelper.Now;
            parkingRecord.Note = request.Note;
            var parkingPlace = await _placeRepository.GetOne(parkingRecord.ParkingPlaceId);
            var rate = parkingPlace.Rate;
            parkingRecord.RateValue = rate.HourlyCost;
            parkingRecord.RateDescription = rate.Description;
            var totalTime = parkingRecord.EndTime.Value - parkingRecord.StartTime;
            var totalCost = (int)totalTime.TotalHours * rate.HourlyCost;
            if(totalCost < rate.MinimumCost)
                totalCost = rate.MinimumCost;
            parkingRecord.TotalCost = totalCost;
            _repository.Update(parkingRecord);
            await _repository.SaveChanges();
            return _mapper.Map<FinishedParkingRecordDto>(parkingRecord);
        }
    }
}
