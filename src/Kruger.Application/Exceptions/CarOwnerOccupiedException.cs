namespace Kruger.Application.Exceptions
{
    public class CarOwnerOccupiedException : ValidationErrorException
    {
        public CarOwnerOccupiedException(string message = "The Car Owner is Occupied")
            : base(message) { }
    }
}
