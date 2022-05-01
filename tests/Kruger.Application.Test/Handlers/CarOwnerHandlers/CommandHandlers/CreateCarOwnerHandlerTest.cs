using AutoMapper;
using Kruger.Application.Commands.CarOwnerCommands;
using Kruger.Application.Exceptions;
using Kruger.Application.Handlers.CarOwnerHandlers.CommandHandlers;
using Kruger.Application.Test.Mocks.Repositories;
using Kruger.Core.Interfaces.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Kruger.Application.Test.Handlers.CarOwnerHandlers.CommandHandlers
{
    public class CreateCarOwnerHandlerTest
    {
        private Mock<ICarOwnerRepository> _carOwnerRepository;
        private IMapper _mapper;

        public CreateCarOwnerHandlerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mappers.Profiles.CarOwnerProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            _carOwnerRepository = MockCarOwnerRepository.GetMock();
        }

        [Fact]
        public async Task Test_Can_Create_CarOwner()
        {
            var handler = new CreateCarOwnerHandler(
                _carOwnerRepository.Object,
                _mapper);
            var command = new CreateCarOwnerCommand
            {
                Name = "Nuevo",
                IdType = Core.Enums.IdType.Id,
                LastName = "Apellido",
                IdValue = "0987654321"
            };
            var result = await handler.Handle(command, default);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Test_Try_Create_CarOwner_With_Identification_Repeat()
        {
            var idValue = "0987654321";
            _carOwnerRepository.Setup(r => r.IsTheIdentificationRepeated(idValue, default)).ReturnsAsync(true);
            var handler = new CreateCarOwnerHandler(
                _carOwnerRepository.Object,
                _mapper);
            var command = new CreateCarOwnerCommand
            {
                Name = "Nuevo",
                IdType = Core.Enums.IdType.Id,
                LastName = "Apellido",
                IdValue = idValue
            };

            await Assert.ThrowsAsync<IdentificationRepeatedException>(async () => await handler.Handle(command, default));
        }
    }
}
