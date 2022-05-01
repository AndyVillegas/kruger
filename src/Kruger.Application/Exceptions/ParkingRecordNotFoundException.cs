namespace Kruger.Application.Exceptions
{
    public class ParkingRecordNotFoundException : NotFoundException
    {
        public ParkingRecordNotFoundException(string message = "The parking record not found")
            : base(message) { }
    }
}
