namespace Kruger.Application.Exceptions
{
    public class ParkingPlaceExceededException : ValidationErrorException
    {
        public ParkingPlaceExceededException(string message = "Parking place exceeded")
            : base(message) { }
    }
}
