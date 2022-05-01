using AutoMapper;
using Common.Helpers.Interfaces;
using Kruger.Application.Commands.ParkingRecordCommands;
using Kruger.Application.Exceptions;
using Kruger.Application.Handlers.ParkingRecordHandlers.CommandHandlers;
using Kruger.Application.Test.Mocks.Repositories;
using Kruger.Core.Interfaces.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Kruger.Application.Test.Handlers.ParkingRecordHandlers.CommandHandlers
{
    public class FinishParkingRecordHandlerTest
    {
        private Mock<IParkingRecordRepository> _repository;
        private Mock<IParkingPlaceRepository> _placeRepository;
        private Mock<IDateTimeHelper> _dateTimeHelper;
        private IMapper _mapper;
        public FinishParkingRecordHandlerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mappers.Profiles.ParkingRecordProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            _repository = MockParkingRecordRepository.GetMock();
            _placeRepository = MockParkingPlaceRepository.GetMock();
            _dateTimeHelper = new Mock<IDateTimeHelper>();
        }

        [Fact]
        public async Task Test_Finish_Parking_Record_Success()
        {
            var startTime = new DateTime(2022, 4, 30, 10, 0, 0);
            var endTime = new DateTime(2022, 4, 30, 11, 30, 0);
            _dateTimeHelper.Setup(x => x.Now).Returns(endTime);
            var handler = new FinishParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new FinishParkingRecordCommand
            {
                Id = 1,
                Note = "Se ha finalizado"
            };
            var result = await handler.Handle(command, default);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(startTime, result.StartTime);
            Assert.Equal(endTime, result.EndTime);
            Assert.Equal(10, result.TotalCost);
            Assert.Equal("01:30:00", result.TotalTime);
        }

        [Fact]
        public async Task Test_Try_Finish_Ended_Parking_Record()
        {
            _dateTimeHelper.Setup(x => x.Now).Returns(DateTime.Now);
            var handler = new FinishParkingRecordHandler(
                _repository.Object,
                _placeRepository.Object,
                _dateTimeHelper.Object,
                _mapper);
            var command = new FinishParkingRecordCommand
            {
                Id = 2,
                Note = "Se ha finalizado"
            };
            await Assert.ThrowsAsync<EndedParkingRecordException>(async () => await handler.Handle(command, default));
        }
    }
}
