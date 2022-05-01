namespace Kruger.Application.Exceptions
{
    public class CarOwnerNotFoundException : NotFoundException
    {
        public CarOwnerNotFoundException(string message = "Car owner not found")
            : base(message) { }
    }
}
