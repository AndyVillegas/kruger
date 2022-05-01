using AutoMapper;
using Common.Helpers.Interfaces;
using Kruger.Application.Commands.ParkingRecordCommands;
using Kruger.Application.DTOs;
using Kruger.Application.Exceptions;
using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kruger.Application.Handlers.ParkingRecordHandlers.CommandHandlers
{
    public class CreateParkingRecordHandler : IRequestHandler<CreateParkingRecordCommand, ParkingRecordDto>
    {
        private readonly IParkingRecordRepository _repository;
        private readonly IParkingPlaceRepository _placeRepository;
        private readonly ICarOwnerRepository _carOwnerRepository;
        private readonly ICarRepository _carRepository;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IMapper _mapper;

        public CreateParkingRecordHandler(
            IParkingRecordRepository repository,
            IParkingPlaceRepository placeRepository,
            ICarOwnerRepository carOwnerRepository,
            ICarRepository carRepository,
            IDateTimeHelper dateTimeHelper,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _repository = repository;
            _placeRepository = placeRepository;
            _carOwnerRepository = carOwnerRepository;
            _carRepository = carRepository;
            _dateTimeHelper = dateTimeHelper;
        }
        public async Task<ParkingRecordDto> Handle(CreateParkingRecordCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);
            var carOwner = await _carOwnerRepository.GetOne(request.CarOwnerId);
            carOwner.LastParking = _dateTimeHelper.Now;
            var parkingPlace = await _placeRepository.GetOne(request.ParkingPlaceId);
            var model = _mapper.Map<ParkingRecord>(request);
            model.RateDescription = parkingPlace.Rate.Description;
            model.RateValue = parkingPlace.Rate.HourlyCost;
            model.TotalCost = parkingPlace.Rate.MinimumCost;
            model.StartTime = _dateTimeHelper.Now;
            var newParkingRecord = await _repository.Create(model);
            await _repository.SaveChanges();
            return _mapper.Map<ParkingRecordDto>(newParkingRecord);
        }
        private async Task ValidateRequest(CreateParkingRecordCommand request)
        {
            var car = await _carRepository.GetOne(request.CarId);
            if (car == null)
                throw new CarNotFoundException();
            var carOwner = await _carOwnerRepository.GetOne(request.CarOwnerId);
            if (carOwner == null)
                throw new CarOwnerNotFoundException();
            var parkingPlace = await _placeRepository.GetOne(request.ParkingPlaceId);
            if (parkingPlace == null)
                throw new ParkingPlaceNotFoundException();
            var isTheCarOwnerOccupied = await _repository.IsTheCarOwnerOccupied(request.CarOwnerId);
            if (isTheCarOwnerOccupied)
                throw new CarOwnerOccupiedException();
            var isTheParkingPlaceOccupied = await _repository.IsTheParkingPlaceOccupied(request.ParkingPlaceId);
            if (isTheParkingPlaceOccupied)
                throw new ParkingPlaceOccupiedException();
            var numberOfCarsOnParkingPlace = await _repository.GetNumberOfRecordsByOccupiedParkingPlace(request.ParkingPlaceId);
            if (numberOfCarsOnParkingPlace >= parkingPlace.Capacity)
                throw new ParkingPlaceExceededException();
        }
    }
}
