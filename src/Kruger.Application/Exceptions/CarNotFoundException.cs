namespace Kruger.Application.Exceptions
{
    public class CarNotFoundException : NotFoundException
    {
        public CarNotFoundException(string message = "Car not found")
            : base(message) { }
    }
}
