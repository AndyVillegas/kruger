using Kruger.Core.Entities;
using Kruger.Core.Interfaces.Repositories;
using Moq;
using System;

namespace Kruger.Application.Test.Mocks.Repositories
{
    public static class MockCarOwnerRepository
    {
        public static Mock<ICarOwnerRepository> GetMock()
        {
            var _carOwnerRepository = new Mock<ICarOwnerRepository>();
            _carOwnerRepository.Setup(r => r.GetOne(1)).ReturnsAsync(new Core.Entities.CarOwner
            {
                CreatedAt = DateTime.Now,
                Name = "Andy",
                LastName = "Villegas",
                Id = 1,
                IdValue = "0940864747",
                IdType = Core.Enums.IdType.Id
            });
            _carOwnerRepository.Setup(r => r.GetOne(2)).ReturnsAsync(new Core.Entities.CarOwner
            {
                CreatedAt = DateTime.Now,
                Name = "Luis",
                LastName = "Villegas",
                Id = 2,
                IdValue = "0940864740",
                IdType = Core.Enums.IdType.Id
            });
            _carOwnerRepository.Setup(r => r.Create(It.IsAny<CarOwner>())).ReturnsAsync((CarOwner carOwner) =>
            {
                carOwner.Id = 1;
                carOwner.CreatedAt = DateTime.Now;
                return carOwner;
            });
            return _carOwnerRepository;
        }
    }
}
