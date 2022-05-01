namespace Kruger.Application.Exceptions
{
    public class RateNotFoundException : NotFoundException
    {
        public RateNotFoundException(string message = "Rate not found")
            : base(message) { }
    }
}
