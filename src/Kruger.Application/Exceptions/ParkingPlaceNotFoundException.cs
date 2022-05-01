namespace Kruger.Application.Exceptions
{
    public class ParkingPlaceNotFoundException : NotFoundException
    {
        public ParkingPlaceNotFoundException(string message = "Parking place not found")
            : base(message) { }
    }
}
