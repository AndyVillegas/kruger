namespace Kruger.Application.Exceptions
{
    public class ParkingPlaceOccupiedException : ValidationErrorException
    {
        public ParkingPlaceOccupiedException(string message = "The Parking Place is occupied")
            : base(message) { }
    }
}
