using AutoMapper;
using Common.Helpers.Interfaces;
using Kruger.Application.Commands.ParkingRecordCommands;
using Kruger.Application.Exceptions;
using Kruger.Application.Handlers.ParkingRecordHandlers.CommandHandlers;
using Kruger.Application.Test.Mocks.Repositories;
using Kruger.Core.Interfaces.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Kruger.Application.Test.Handlers.ParkingRecordHandlers.CommandHandlers
{
    public class CreateParkingRecordHandlerTest
    {
        private Mock<IParkingRecordRepository> _repository;
        private Mock<IParkingPlaceRepository> _placeRepository;
        private Mock<ICarOwnerRepository> _carOwnerRepository;
        private Mock<ICarRepository> _carRepository;
        private Mock<IDateTimeHelper> _dateTimeHelper;
        private IMapper _mapper;
        public CreateParkingRecordHandlerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mappers.Profiles.ParkingRecordProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            _repository = MockParkingRecordRepository.GetMock();
            _carOwnerRepository = MockCarOwnerRepository.GetMock();
            _placeRepository = MockParkingPlaceRepository.GetMock();
            _carRepository = MockCarRepository.GetMock();
            _dateTimeHelper = new Mock<IDateTimeHelper>();
        }

        [Fact]
        public async Task Test_Create_Parking_Record_Success()
        {
            var handler = new CreateParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _carOwnerRepository.Object,
                _carRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new CreateParkingRecordCommand
            {
                CarId = 1,
                CarOwnerId = 1,
                ParkingPlaceId = 1,
            };
            var result = await handler.Handle(command, default);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Test_Create_Parking_Record_Car_Not_Found()
        {
            var handler = new CreateParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _carOwnerRepository.Object,
                _carRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new CreateParkingRecordCommand
            {
                CarId = 100,
                CarOwnerId = 1,
                ParkingPlaceId = 1,
            };
            await Assert.ThrowsAsync<CarNotFoundException>(() => handler.Handle(command, default));
        }

        [Fact]
        public async Task Test_Create_Parking_Record_CarOwner_Not_Found()
        {
            var handler = new CreateParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _carOwnerRepository.Object,
                _carRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new CreateParkingRecordCommand
            {
                CarId = 1,
                CarOwnerId = 100,
                ParkingPlaceId = 1,
            };
            await Assert.ThrowsAsync<CarOwnerNotFoundException>(() => handler.Handle(command, default));
        }

        [Fact]
        public async Task Test_Create_Parking_Record_ParkingPlace_Not_Found()
        {
            var handler = new CreateParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _carOwnerRepository.Object,
                _carRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new CreateParkingRecordCommand
            {
                CarId = 1,
                CarOwnerId = 1,
                ParkingPlaceId = 100,
            };
            await Assert.ThrowsAsync<ParkingPlaceNotFoundException>(() => handler.Handle(command, default));
        }

        [Fact]
        public async Task Test_Create_Parking_Record_With_Occupied_OwnerCar()
        {
            _repository.Setup(r => r.IsTheCarOwnerOccupied(1)).ReturnsAsync(true);
            var handler = new CreateParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _carOwnerRepository.Object,
                _carRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new CreateParkingRecordCommand
            {
                CarId = 1,
                CarOwnerId = 1,
                ParkingPlaceId = 1,
            };
            await Assert.ThrowsAsync<CarOwnerOccupiedException>(() => handler.Handle(command, default));
        }

        [Fact]
        public async Task Test_Create_Parking_Record_With_Occupied_ParkingPlace()
        {
            _repository.Setup(r => r.IsTheParkingPlaceOccupied(1)).ReturnsAsync(true);
            var handler = new CreateParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _carOwnerRepository.Object,
                _carRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new CreateParkingRecordCommand
            {
                CarId = 1,
                CarOwnerId = 1,
                ParkingPlaceId = 1,
            };
            await Assert.ThrowsAsync<ParkingPlaceOccupiedException>(() => handler.Handle(command, default));
        }

        [Fact]
        public async Task Test_Try_Create_Parking_Record_And_Throw_Exceeded_Parking_Place()
        {
            _repository.Setup(e => e.GetNumberOfRecordsByOccupiedParkingPlace(1)).ReturnsAsync(5);
            var handler = new CreateParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _carOwnerRepository.Object,
                _carRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new CreateParkingRecordCommand
            {
                CarId = 1,
                CarOwnerId = 1,
                ParkingPlaceId = 1,
            };
            await Assert.ThrowsAsync<ParkingPlaceExceededException>(() => handler.Handle(command, default));
        }
    }
}
