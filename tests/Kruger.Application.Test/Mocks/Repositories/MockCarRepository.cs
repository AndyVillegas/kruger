using Kruger.Core.Interfaces.Repositories;
using Moq;
using System;

namespace Kruger.Application.Test.Mocks.Repositories
{
    public static class MockCarRepository
    {
        public static Mock<ICarRepository> GetMock()
        {
            var _carRepository = new Mock<ICarRepository>();
            _carRepository.Setup(r => r.GetOne(1)).ReturnsAsync(new Core.Entities.Car
            {
                Id = 1,
                Plate = "ABC1234",
                CreatedAt = DateTime.Now,
            });
            _carRepository.Setup(r => r.GetOne(2)).ReturnsAsync(new Core.Entities.Car
            {
                Id = 2,
                Plate = "ABC1234",
                CreatedAt = DateTime.Now,
            });
            return _carRepository;
        }
    }
}
