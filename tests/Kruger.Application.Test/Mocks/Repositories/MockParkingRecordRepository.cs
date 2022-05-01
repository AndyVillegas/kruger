using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using Moq;
using System;

namespace Kruger.Application.Test.Mocks.Repositories
{
    public static class MockParkingRecordRepository
    {
        public static Mock<IParkingRecordRepository> GetMock()
        {
            var _repository = new Mock<IParkingRecordRepository>();
            _repository.Setup(r => r.SaveChanges());
            _repository.Setup(r => r.Create(It.IsAny<ParkingRecord>())).ReturnsAsync((ParkingRecord parkingRecord) =>
            {
                parkingRecord.Id = 1;
                parkingRecord.CreatedAt = DateTime.Now;
                return parkingRecord;
            });
            _repository.Setup(r => r.GetOne(1)).ReturnsAsync(new ParkingRecord
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                StartTime = new DateTime(2022,4,30,10,0,0),
                CarOwnerId = 1,
                CarId = 1,
                ParkingPlaceId = 1,

            });
            _repository.Setup(r => r.GetOne(2)).ReturnsAsync(new ParkingRecord
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                StartTime = new DateTime(2022, 4, 30, 10, 0, 0),
                EndTime = new DateTime(2022, 4, 30, 11, 30, 0),
                CarOwnerId = 1,
                CarId = 1,
                ParkingPlaceId = 1,

            });
            return _repository;
        }
    }
}
