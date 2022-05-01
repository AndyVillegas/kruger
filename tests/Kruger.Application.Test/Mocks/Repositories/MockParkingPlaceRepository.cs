using Kruger.Core.Interfaces.Repositories;
using Moq;
using System;

namespace Kruger.Application.Test.Mocks.Repositories
{
    public static class MockParkingPlaceRepository
    {
        public static Mock<IParkingPlaceRepository> GetMock()
        {
            var _placeRepository = new Mock<IParkingPlaceRepository>();
            _placeRepository.Setup(r => r.GetOne(1)).ReturnsAsync(new Core.Entities.ParkingPlace
            {
                Id = 1,
                Capacity = 5,
                CreatedAt = DateTime.Now,
                Description = "Place #1",
                RateId = 1,
                Rate = new Core.Entities.Rate
                {
                    Id = 1,
                    Description = "Rate A",
                    HourlyCost = 10,
                    MinimumCost = 5,
                    CreatedAt = DateTime.Now,
                }
            });
            return _placeRepository;
        }
    }
}
